
namespace GurbForumUser.Client.Services.UI
{
    public class RefreshStateService
    {
        public delegate void RefreshDelegate();
        public RefreshDelegate? RefreshSectionList;

        public delegate Task OpenChatBoxDelegate(string userName);
        public OpenChatBoxDelegate? OpenChatBox;

        public delegate Task ConnectChatHubWhenLoginDelegate();
        public ConnectChatHubWhenLoginDelegate ConnectChatHubWhenLogin;

        public RefreshStateService()
        {
            
        }
    }
}
