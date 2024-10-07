namespace NarForumAdmin.Services.Common
{
    public class AlertService
    {
        public event Action<string> OnShow;
        public event Action OnHide;

        public void ShowAlert(string message)
        {
            OnShow?.Invoke(message);
        }

        public void HideAlert()
        {
            OnHide?.Invoke();
        }
    }
}
