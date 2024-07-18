using Application.Contracts.Hubs;
using Application.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

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


        public async Task SendChatRequest(string toUser, string message)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string? userName = httpContext.Request.Query["username"];

                var toUserConnectionId = await _cache.GetValueAsync($"chat:connection:{toUser}");

                await _cache.AppendListAsync($"chat-requests:{toUser}", message);

                if (!string.IsNullOrEmpty(toUserConnectionId) && userName is not null)
                {
                    await Clients.Client(toUserConnectionId).ReceiveChatRequest(userName, message);
                }
            }
        }

        public async Task SendMessage(string toUser, string message)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string connectionId = Context.ConnectionId;
                //string? userName = httpContext.Request.Query["username"];
                //string? group = httpContext.Request.Query["group"];

                var toUserConnectionId = await _cache.GetValueAsync($"chat:connection:{toUser}");

                await _cache.AppendListAsync($"messages:{toUser}", message);

                if (!string.IsNullOrEmpty(toUserConnectionId))
                {
                    await Clients.Client(toUserConnectionId).ReceiveMessage(toUser, message);
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
