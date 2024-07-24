using Application.Contracts.Hubs;
using Application.Contracts.Identity;
using Application.Models.Identity.Message;
using Identity.Models.DTO;
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
            }

            await base.OnConnectedAsync();
        }

        public async Task GetChatHistory()
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string? userName = httpContext.Request.Query["username"];
                var toUserConnectionId = await _cache.GetValueAsync($"chat:connection:{userName}");

                HashScanResult chatHistory = await _cache.HashScan("chat-requests", 
                    new string[] {
                        $"chat-requests:{userName}:*",
                        $"chat-requests:*:{userName}:*"
                    }, 
                    100);
               

                if (!string.IsNullOrEmpty(toUserConnectionId) && userName is not null && chatHistory.IsSuccess && chatHistory.Length > 0)
                {
                    var chatHistoryString = JsonConvert.SerializeObject(chatHistory);
                    await Clients.Client(toUserConnectionId).ReceiveChatHistory(userName, chatHistoryString);
                }

                HashScanResult messageHistory = await _cache.HashScan("messages",
                    new string[] {
                        $"messages:{userName}:*",
                        $"messages:*:{userName}:*"
                    },
                    100);

                if (!string.IsNullOrEmpty(toUserConnectionId) && userName is not null && messageHistory.IsSuccess && messageHistory.Length > 0)
                {
                    var messageHistoryString = JsonConvert.SerializeObject(messageHistory);
                    await Clients.Client(toUserConnectionId).ReceiveMessageHistory(userName, messageHistoryString);
                }
            }
        }

        public async Task SendChatRequest(string chatId, string toUser, string receiverId, string subject, string message)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string? userName = httpContext.Request.Query["username"];
                string? userId = httpContext.Request.Query["userId"];

                var toUserConnectionId = await _cache.GetValueAsync($"chat:connection:{toUser}");

                ChatDTO chatDto = new ChatDTO
                {
                    Id = chatId,
                    Subject = subject,
                    Message = message,
                    Creator = new UserDTO { UserName = userName },
                    CreatorId = userId,
                    Receiver = new UserDTO { UserName = toUser },
                    ReceiverId = receiverId,
                    Status = Application.Models.Enums.ChatStatus.Pending,
                    DateTime = DateTime.UtcNow,
                };

                var chatRequestString = JsonConvert.SerializeObject(chatDto);

                await _cache.AddHashSet("chat-requests", $"chat-requests:{toUser}:{userName}:{chatDto.Id}", chatRequestString);

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
                string? userId = httpContext.Request.Query["userId"];
                var toUserConnectionId = await _cache.GetValueAsync($"chat:connection:{toUser}");

                MessageDTO messageDto = new MessageDTO
                {
                    Id = messageId,
                    ChatId = chatId,
                    DateTime = DateTime.UtcNow,
                    Owner = new UserDTO { UserName = userName, },
                    OwnerId = userId,
                    IsRead = false,
                    Text = message,
                };

                var messageString = JsonConvert.SerializeObject(messageDto);

                await _cache.AddHashSet("messages", $"messages:{toUser}:{userName}:{chatId}:{messageId}", messageString);

                if (!string.IsNullOrEmpty(toUserConnectionId) && userName is not null)
                {
                    await Clients.Client(toUserConnectionId).ReceiveMessage(userName, messageString);
                }
            }
        }


        public async Task AcceptChatRequest(string chatId, string toUser, bool isAccept, string chatRequestStringDB)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string? userName = httpContext.Request.Query["username"];

                var toUserConnectionId = await _cache.GetValueAsync($"chat:connection:{toUser}");

                string chatRequestString = await _cache.GetHashSet("chat-requests", $"chat-requests:{userName}:{toUser}:{chatId}");

                ChatDTO? chatDto;

                if (chatRequestString is null)
                {
                    string acceptValue = "0";

                    chatDto = JsonConvert.DeserializeObject<ChatDTO>(chatRequestStringDB);

                    if (isAccept)
                    {
                        acceptValue = "1";
                        chatDto!.Status = Application.Models.Enums.ChatStatus.Approved;
                        await _cache.AddHashSet("chat-requests-db", chatId, acceptValue);
                    }
                    else
                    {
                        acceptValue = "2";
                        chatDto!.Status = Application.Models.Enums.ChatStatus.Rejected;
                        await _cache.AddHashSet("chat-requests-db", chatId, acceptValue);
                    }

                    string newChatRequestStringDB = JsonConvert.SerializeObject(chatDto);

                    await _cache.AddHashSet("chat-requests", $"chat-requests:{userName}:{toUser}:{chatDto.Id}", newChatRequestStringDB);

                    if (!string.IsNullOrEmpty(toUserConnectionId) && userName is not null)
                    {
                        await Clients.Client(toUserConnectionId).ReceiveChatResponse(userName, newChatRequestStringDB);
                    }
                    return;
                }

                chatDto = JsonConvert.DeserializeObject<ChatDTO>(chatRequestString);

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
                    //await _cache.SetValueAsync($"chat-requests:{userName}:{chatDto.Id}", chatRequestString);
                    await _cache.AddHashSet("chat-requests", $"chat-requests:{userName}:{toUser}:{chatDto.Id}", chatRequestString);
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
