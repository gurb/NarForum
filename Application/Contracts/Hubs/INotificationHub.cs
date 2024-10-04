using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Hubs
{
    public interface INotificationHub
    {
        Task ReceiveNotification(List<string> message);
    }
}
