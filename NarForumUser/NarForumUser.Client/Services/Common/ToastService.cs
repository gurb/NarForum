using NarForumUser.Client.Models.Toast;

namespace NarForumUser.Client.Services.Common
{
    public class ToastService
    {
        public event Action<ToastNotification>? AddNotificationAction;

        public void AddNotification(ToastNotification notification)
        {
            if(AddNotificationAction is not null)
            {
                AddNotificationAction.Invoke(notification);
            }
        }
    }
}
