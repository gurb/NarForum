using Application.Contracts.Hubs;
using Application.Contracts.Identity;
using Application.Features.Category.Queries.GetCategories;
using Application.Features.Heading.Queries;
using Application.Models.Identity.Message;
using Application.Models.Identity.Notification;
using Domain;
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
                await _cache.RemoveFieldHashSet($"notifications:{userName}", $"{notificationId}");

                var userConnectionId = await _cache.GetValueAsync($"notification:connection:{userName}");
               
                if (userConnectionId is not null && userName is not null)
                {
                    await SendNotifications(userConnectionId, userName);
                }
            }
        }

        public async Task ClearNotifications()
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                string? userName = httpContext.Request.Query["username"];
                string? userId = httpContext.Request.Query["userId"];

                if(userName is not null)
                {
                    await _cache.Clear($"notifications:{userName}");

                    var userConnectionId = await _cache.GetValueAsync($"notification:connection:{userName}");

                    if (userConnectionId is not null)
                    {
                        await SendNotifications(userConnectionId, userName);
                    }
                }
            }
        }

        public async Task ReadNotification(string? notificationId)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null && notificationId is not null)
            {
                string? userName = httpContext.Request.Query["username"];
                string? userId = httpContext.Request.Query["userId"];

                string? notificationString = await _cache.GetHashSet($"notifications:{userName}", notificationId);

                if(notificationString is not null)
                {
                    NotificationDTO? notification = JsonConvert.DeserializeObject<NotificationDTO>(notificationString);

                    if (notification is not null)
                    {
                        notification.IsRead = true;

                        notificationString = JsonConvert.SerializeObject(notification);

                        await _cache.AddHashSet($"notifications:{userName}", $"{notificationId}", notificationString);

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
            Dictionary<string, string>? notifications = await _cache.GetAllHashSet($"notifications:{userName}");

            if (notifications is not null && notifications.Count > 0)
            {
                List<string> notificationMessages = new List<string>();
                foreach (var notification in notifications)
                {
                    notificationMessages.Add(notification.Value);
                }

                var notificationMessagesString = JsonConvert.SerializeObject(notificationMessages);
                await Clients.Client(userConnectionId).ReceiveNotification(notificationMessagesString);
            }
            else
            {
                await Clients.Client(userConnectionId).ReceiveNotification(null);
            }
        }


        public async Task SendNotificationForHeading(HeadingDTO heading, CategoryDTO category, string ownerHeading, string? ownerHeadingId)
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
                    Message = $"There is a new post for your {heading.Title} by {userName}",
                    Category = category,
                    Heading  = heading,
                    Creator = new UserDTO { UserName = userName },
                    CreatorId = userId,
                    Receiver = new UserDTO { UserName = ownerHeading },
                    ReceiverId = ownerHeadingId,
                    Type = Application.Models.Enums.NotificationType.RepliedHeading,
                    DateTime = DateTime.UtcNow,
                    IsRead = false,
                };

                var notificationRequest = JsonConvert.SerializeObject(notification);

                await _cache.AddHashSet($"notifications:{ownerHeading}", $"{notification.Id}", notificationRequest);
            }
        }

        public async Task SendNotificationForReply(HeadingDTO heading, CategoryDTO category, string ownerPost, string? ownerPostId)
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
                    Message = $"There is a reply for your post at {heading.Title} by {userName}",
                    Category = category,
                    Heading = heading,
                    Creator = new UserDTO { UserName = userName },
                    CreatorId = userId,
                    Receiver = new UserDTO { UserName = ownerPost },
                    ReceiverId = ownerPostId,
                    Type = Application.Models.Enums.NotificationType.RepliedPost,
                    DateTime = DateTime.UtcNow,
                    IsRead = false,
                };

                var notificationRequest = JsonConvert.SerializeObject(notification);

                await _cache.AddHashSet($"notifications:{ownerPost}", $"{notification.Id}", notificationRequest);
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
