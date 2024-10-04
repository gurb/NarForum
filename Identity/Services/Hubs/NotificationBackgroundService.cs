using Application.Contracts.Hubs;
using Application.Contracts.Identity;
using Identity.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

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
                Dictionary<string, string>? forumActiveUserHashSet = await _cache.GetAllHashSet("forumActiveUsers");

                // if there are online users
                if(forumActiveUserHashSet is not null)
                {
                    foreach (var activeUser in forumActiveUserHashSet)
                    {
                        // activeUser.Key equals username of online users
                        Dictionary<string, string>? notifications = await _cache.GetAllHashSet($"notifications:{activeUser.Key}");
                        var userConnection = await _cache.GetValueAsync($"notification:connection:{activeUser.Key}");
                        
                        if(userConnection is not null && notifications is not null)
                        {
                            string ownerHeading = activeUser.Key;
                            
                            if(notifications is not null && notifications.Count > 0)
                            {
                                List<string> notificationMessages = new List<string>();
                                foreach(var notification in notifications)
                                {
                                    notificationMessages.Add(notification.Value);
                                }

                                var notificationMessagesString = JsonConvert.SerializeObject(notificationMessages);
                                await _hubContext.Clients.Client(userConnection).ReceiveNotification(notificationMessagesString);
                                notifications.Clear();
                            }
                        }
                    }
                    forumActiveUserHashSet.Clear();
                }
            }
        }
    }
}
