using Application.Contracts.Hubs;
using Identity.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Identity.Services.Hubs
{
    public class NotificationBackgroundService : BackgroundService
    {
        private static readonly TimeSpan Periond = TimeSpan.FromSeconds(5);
        private readonly ILogger<NotificationBackgroundService> _logger;
        private readonly IHubContext<NotificationHub, INotificationHub> _hubContext;

        public NotificationBackgroundService(ILogger<NotificationBackgroundService> logger, IHubContext<NotificationHub, INotificationHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(Periond);

            while(!stoppingToken.IsCancellationRequested &&
                await timer.WaitForNextTickAsync(stoppingToken))
            {
                var dateTime = DateTime.UtcNow;


                await _hubContext.Clients.All.ReceiveNotification($"Server time = {dateTime}");
            }
        }
    }
}
