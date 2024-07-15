
namespace BlazorUI.Services.UI
{
    public class RefreshStateService
    {
        public delegate void RefreshDelegate();
        public RefreshDelegate? RefreshSectionList;

        public delegate Task OpenChatBoxDelegate(string userName);
        public OpenChatBoxDelegate? OpenChatBox;

        public RefreshStateService()
        {
            
        }
    }
}
