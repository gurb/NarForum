using Application.Contracts.Hubs;
using Application.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;


namespace Identity.Hubs
{
    [Authorize]
    public class TrackHub : Hub<ITrackHub>
    {
        private readonly IGarnetCacheService _cache;

        public TrackHub(IGarnetCacheService cache)
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

                if(userName != null)
                {
                    await _cache.AddHashSet("activeUsers", userName, connectionId);
                }
            }

            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

    }
}
