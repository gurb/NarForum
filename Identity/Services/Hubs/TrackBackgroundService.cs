using Application.Contracts.Hubs;
using Application.Contracts.Identity;
using Application.Models.Identity.Hub;
using Identity.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Identity.Services.Hubs
{
    public class TrackBackgroundService : BackgroundService
    {
        private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(10);
        private readonly IHubContext<TrackHub, ITrackHub> _context;
        private readonly IGarnetCacheService _cache;

        public TrackBackgroundService(IHubContext<TrackHub, ITrackHub> context, IGarnetCacheService cache)
        {
            _context = context;
            _cache = cache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(Timeout);

            while (!stoppingToken.IsCancellationRequested &&
                await timer.WaitForNextTickAsync(stoppingToken))
            {
                List<ActiveUser> activeUsers = new List<ActiveUser>();
                Dictionary<string, string>? forumActiveUserHashSet = await _cache.GetAllHashSet("forumActiveUsers");

                if (forumActiveUserHashSet is not null)
                {
                    foreach (var activeUser in forumActiveUserHashSet)
                    {
                        activeUsers.Add(new ActiveUser { ConnectionId = activeUser.Value, UserName = activeUser.Key });
                    }
                }

                var jsonStr = JsonConvert.SerializeObject(activeUsers);
                await _context.Clients.All.ReceiveActiveUsers(jsonStr);
            }
        }
    }
}
