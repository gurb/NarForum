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
