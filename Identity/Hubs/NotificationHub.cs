using Application.Contracts.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
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
        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId)
                .ReceiveNotification($"thank you connection {Context.User?.Identity?.Name}");

            await base.OnConnectedAsync();
        }
    }
}
