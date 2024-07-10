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

                var messageHistory = await _cache.GetList($"messages:{userName}");
                if(messageHistory != null && messageHistory.Count > 0)
                {
                    foreach (var message in messageHistory)
                    {
                        //await Clients.Caller.ReceiveMessage();
                    }
                }
            }

            await base.OnConnectedAsync();
        }


        public async Task SendMessage(string fromUser, string toUser, string message)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string connectionId = Context.ConnectionId;
                //string? userName = httpContext.Request.Query["username"];
                //string? group = httpContext.Request.Query["group"];

                var toUserConnectionId = await _cache.GetValueAsync($"chat:connection:{toUser}");

                //await _cache.AppendListAsync($"messages:{toUser}", );


                if (!string.IsNullOrEmpty(toUserConnectionId))
                {
                    //await Clients.Client(toUserConnectionId).ReceiveMessage();
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
