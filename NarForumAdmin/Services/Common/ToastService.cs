using NarForumAdmin.Models.Toast;

namespace NarForumAdmin.Services.Common
{
    public class ToastService
    {
        public event Action<ToastNotification>? AddNotificationAction;

        public void AddNotification(ToastNotification notification)
        {
            if (AddNotificationAction is not null)
            {
                AddNotificationAction.Invoke(notification);
            }
        }

        public void CreateSuccessToast(string title, string message)
        {
            if (AddNotificationAction is not null)
            {
                ToastNotification notification = new ToastNotification();
                notification.Title = title;
                notification.Message = message;
                notification.Type = Models.Enums.ToastTypeVM.Success;

                AddNotificationAction.Invoke(notification);
            }
        }
        public void CreateErrorToast(string title, string message)
        {
            if (AddNotificationAction is not null)
            {
                ToastNotification notification = new ToastNotification();
                notification.Title = title;
                notification.Message = message;
                notification.Type = Models.Enums.ToastTypeVM.Error;

                AddNotificationAction.Invoke(notification);
            }
        }

        public void CreateInfoToast(string title, string message)
        {
            if (AddNotificationAction is not null)
            {
                ToastNotification notification = new ToastNotification();
                notification.Title = title;
                notification.Message = message;
                notification.Type = Models.Enums.ToastTypeVM.Info;

                AddNotificationAction.Invoke(notification);
            }
        }
    }
}
