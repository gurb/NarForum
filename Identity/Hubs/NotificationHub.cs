using Application.Contracts.Hubs;
using Application.Contracts.Identity;
using Application.Models.Identity.Message;
using Application.Models.Identity.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Hubs
{
    [Authorize]
    public class NotificationHub: Hub<INotificationHub>
    {
        private readonly IGarnetCacheService _cache;

        public NotificationHub(IGarnetCacheService cache)
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

                await _cache.SetValueAsync($"notification:connection:{userName}", connectionId);
            }

            await base.OnConnectedAsync();
        }


        public async Task RemoveNotification(string? notificationId)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string? userName = httpContext.Request.Query["username"];
                string? userId = httpContext.Request.Query["userId"];
                await _cache.RemoveFieldHashSet("notifications", $"{userName}:{notificationId}");

                var userConnectionId = await _cache.GetValueAsync($"notification:connection:{userName}");

                if (!string.IsNullOrEmpty(userConnectionId))
                {
                    if (userConnectionId is not null && userName is not null)
                    {
                        await SendNotifications(userConnectionId, userName);
                    }
                }
            }
        }

        public async Task ReadNotification(string? notificationId)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string? userName = httpContext.Request.Query["username"];
                string? userId = httpContext.Request.Query["userId"];

                string? notificationString = await _cache.GetHashSet("notifications", $"{userName}:{notificationId}");

                if(notificationString is not null)
                {
                    NotificationDTO? notification = JsonConvert.DeserializeObject<NotificationDTO>(notificationString);

                    if (notification is not null)
                    {
                        notification.IsRead = true;

                        notificationString = JsonConvert.SerializeObject(notification);

                        await _cache.AddHashSet("notifications", $"{userName}:{notificationId}", notificationString);

                        var userConnectionId = await _cache.GetValueAsync($"notification:connection:{userName}");

                        if(userConnectionId is not null && userName is not null)
                        {
                            await SendNotifications(userConnectionId, userName);
                        }
                    }
                }
            }
        }


        private async Task SendNotifications(string userConnectionId, string userName)
        {
            Dictionary<string, string>? notifications = await _cache.GetAllHashSet("notifications");

            if (notifications is not null && notifications.Count > 0)
            {
                var filteredNotifications = notifications.Where(x => x.Key.StartsWith(userName))
                        .ToDictionary(x => x.Key, x => x.Value);

                if (filteredNotifications is not null && filteredNotifications.Count > 0)
                {
                    List<string> notificationMessages = new List<string>();
                    foreach (var notification in filteredNotifications)
                    {
                        notificationMessages.Add(notification.Value);
                    }

                    var notificationMessagesString = JsonConvert.SerializeObject(notificationMessages);
                    await Clients.Client(userConnectionId).ReceiveNotification(notificationMessagesString);
                }
            }
        }


        public async Task SendNotificationForHeading(Guid? headingId, string? headingTitle, string ownerHeading, string? ownerHeadingId)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                // sender
                string? userName = httpContext.Request.Query["username"];
                string? userId = httpContext.Request.Query["userId"];

                NotificationDTO notification = new NotificationDTO
                {
                    Id = Guid.NewGuid().ToString(),
                    Message = $"There is a new post for your {headingTitle} by {userName}",
                    HeadingId = headingId,
                    Creator = new UserDTO { UserName = userName },
                    CreatorId = userId,
                    Receiver = new UserDTO { UserName = ownerHeading },
                    ReceiverId = ownerHeadingId,
                    Type = Application.Models.Enums.NotificationType.RepliedHeading,
                    DateTime = DateTime.UtcNow,
                    IsRead = false,
                };

                var notificationRequest = JsonConvert.SerializeObject(notification);

                await _cache.AddHashSet("notifications", $"{ownerHeading}:{notification.Id}", notificationRequest);
            }
        }

        public async Task SendNotificationForReply(Guid? headingId, int? headingIndex, string? headingTitle, string ownerPost, string? ownerPostId)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                // sender
                string? userName = httpContext.Request.Query["username"];
                string? userId = httpContext.Request.Query["userId"];

                NotificationDTO notification = new NotificationDTO
                {
                    Id = Guid.NewGuid().ToString(),
                    Message = $"There is a reply for your post at {headingTitle} by {userName}",
                    HeadingId = headingId,
                    HeadingIndex = headingIndex,
                    Creator = new UserDTO { UserName = userName },
                    CreatorId = userId,
                    Receiver = new UserDTO { UserName = ownerPost },
                    ReceiverId = ownerPostId,
                    Type = Application.Models.Enums.NotificationType.RepliedPost,
                    DateTime = DateTime.UtcNow,
                    IsRead = false,
                };

                var notificationRequest = JsonConvert.SerializeObject(notification);

                await _cache.AddHashSet("notifications", $"{ownerPost}:{notification.Id}", notificationRequest);
            }
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string? userName = httpContext.Request.Query["username"];

                _cache.Clear($"notification:connection:{userName}");
            }

            return base.OnDisconnectedAsync(exception);
        }

    }
}
