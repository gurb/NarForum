using Application.Contracts.Hubs;
using Application.Contracts.Identity;
using Application.Models.Identity.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Identity.Hubs
{
    [Authorize]
    public class ChatHub: Hub<IChatHub>
    {
        private readonly IGarnetCacheService _cache;

        public ChatHub(IGarnetCacheService cache) 
        {
            _cache = cache;
        }
        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string connectionId = Context.ConnectionId;
                string? userName = httpContext.Request.Query["username"];

                await _cache.SetValueAsync($"chat:connection:{userName}", connectionId);

                var chatRequestHistory = await _cache.GetList($"chat-requests:{userName}");
                if (chatRequestHistory != null && chatRequestHistory.Count > 0 && userName is not null)
                {
                    foreach (var chatRequest in chatRequestHistory)
                    {
                        await Clients.Caller.ReceiveChatRequest(userName, chatRequest);
                    }
                }

                var messageHistory = await _cache.GetList($"messages:{userName}");
                if(messageHistory != null && messageHistory.Count > 0 && userName is not null)
                {
                    foreach (var message in messageHistory)
                    {
                        await Clients.Caller.ReceiveMessage(userName, message);
                    }
                }
            }

            await base.OnConnectedAsync();
        }

        public async Task SendChatRequest(string chatId, string toUser, string subject, string message)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string? userName = httpContext.Request.Query["username"];

                var toUserConnectionId = await _cache.GetValueAsync($"chat:connection:{toUser}");

                ChatDTO chatDto = new ChatDTO
                {
                    Id = chatId,
                    Subject = subject,
                    Text = message,
                    Owner = new UserDTO { UserName = userName },
                    Receiver = new UserDTO { UserName = toUser },
                    Status = Application.Models.Enums.ChatStatus.Pending,
                    DateTime = DateTime.UtcNow,
                };

                var chatRequestString = JsonConvert.SerializeObject(chatDto);

                await _cache.SetValueAsync($"chat-requests:{toUser}:{chatDto.Id}", chatRequestString);

                if (!string.IsNullOrEmpty(toUserConnectionId) && userName is not null)
                {
                    await Clients.Client(toUserConnectionId).ReceiveChatRequest(userName, chatRequestString);
                }
            }
        }

        public async Task SendMessage(string chatId, string messageId, string toUser, string message)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string? userName = httpContext.Request.Query["username"];
                var toUserConnectionId = await _cache.GetValueAsync($"chat:connection:{toUser}");

                MessageDTO messageDto = new MessageDTO
                {
                    Id = messageId,
                    ChatId = chatId,
                    DateTime = DateTime.UtcNow,
                    Owner = new UserDTO { UserName = userName },
                    IsRead = false,
                    Text = message,
                };

                var messageString = JsonConvert.SerializeObject(messageDto);

                await _cache.SetValueAsync($"messages:{toUser}:{chatId}:{messageId}", messageString);

                if (!string.IsNullOrEmpty(toUserConnectionId) && userName is not null)
                {
                    await Clients.Client(toUserConnectionId).ReceiveMessage(userName, messageString);
                }
            }
        }


        public async Task AcceptChatRequest(string chatId, string toUser, bool isAccept)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string? userName = httpContext.Request.Query["username"];

                var toUserConnectionId = await _cache.GetValueAsync($"chat:connection:{toUser}");

                string chatRequestString = await _cache.GetValueAsync($"chat-requests:{userName}:{chatId}");
                var chatDto = JsonConvert.DeserializeObject<ChatDTO>(chatRequestString);

                if(chatDto is not null)
                {
                    if(isAccept)
                    {
                        chatDto.Status = Application.Models.Enums.ChatStatus.Approved;
                    }
                    else
                    {
                        chatDto.Status = Application.Models.Enums.ChatStatus.Rejected;
                    }

                    chatRequestString = JsonConvert.SerializeObject(chatDto);
                    await _cache.SetValueAsync($"chat-requests:{userName}:{chatDto.Id}", chatRequestString);
                }

                if (!string.IsNullOrEmpty(toUserConnectionId) && userName is not null)
                {
                    await Clients.Client(toUserConnectionId).ReceiveChatResponse(userName, chatRequestString);
                }
            }
        }

        


        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string? userName = httpContext.Request.Query["username"];

                _cache.Clear($"chat:connection:{userName}");
            }

            return base.OnDisconnectedAsync(exception);
        }

    }
}
