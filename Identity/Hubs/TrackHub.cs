using Application.Contracts.Hubs;
using Application.Contracts.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


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

            var transportType = Context.Features.Get<IHttpTransportFeature>().TransportType;

            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string connectionId = Context.ConnectionId;
                string? userName = httpContext.Request.Query["username"];
                string? group = httpContext.Request.Query["group"];

                if(userName is not null && group is not null)
                {
                    await _cache.AddHashSet($"{group}ActiveUsers", userName, connectionId);
                }
            }



            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string? userName = httpContext.Request.Query["username"];
                string? group = httpContext.Request.Query["group"];

                if (userName is not null && group is not null)
                {
                    await _cache.RemoveFieldHashSet($"{group}ActiveUsers", userName);
                }
            }
            Trace.WriteLine(Context.ConnectionId + "- disconnected");

            await base.OnDisconnectedAsync(exception);
        }

    }
}
