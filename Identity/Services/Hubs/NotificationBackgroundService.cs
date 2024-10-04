using Application.Contracts.Hubs;
using Application.Contracts.Identity;
using Identity.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Identity.Services.Hubs
{
    public class NotificationBackgroundService : BackgroundService
    {
        private static readonly TimeSpan Periond = TimeSpan.FromSeconds(10);
        private readonly IHubContext<NotificationHub, INotificationHub> _hubContext;
        private readonly IGarnetCacheService _cache;

        public NotificationBackgroundService(IHubContext<NotificationHub, INotificationHub> hubContext, IGarnetCacheService cache)
        {
            _hubContext = hubContext;
            _cache = cache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(Periond);

            while(!stoppingToken.IsCancellationRequested &&
                await timer.WaitForNextTickAsync(stoppingToken))
            {
                var dateTime = DateTime.UtcNow;

                Dictionary<string, string>? notifications = await _cache.GetAllHashSet("notifications");
                Dictionary<string, string>? forumActiveUserHashSet = await _cache.GetAllHashSet("forumActiveUsers");

                // if there are online users
                if(forumActiveUserHashSet is not null)
                {
                    foreach (var activeUser in forumActiveUserHashSet)
                    {
                        // activeUser.Key equals username of online users 
                        var userConnection = await _cache.GetValueAsync($"notification:connection:{activeUser.Key}");
                        if(userConnection is not null && notifications is not null)
                        {
                            string ownerHeading = activeUser.Key;
                            var filteredNotifications = notifications.Where(x => x.Key.StartsWith(ownerHeading))
                                .ToDictionary(x => x.Key, x => x.Value);
                            
                            if(filteredNotifications is not null && filteredNotifications.Count > 0)
                            {
                                foreach(var notification in filteredNotifications)
                                {
                                    await _hubContext.Clients.Client(userConnection).ReceiveNotification(notification.Value);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
