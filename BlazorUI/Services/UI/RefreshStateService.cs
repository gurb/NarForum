
namespace BlazorUI.Services.UI
{
    public class RefreshStateService
    {
        public delegate void RefreshDelegate();
        public RefreshDelegate? RefreshSectionList;

        public RefreshStateService()
        {
            
        }
    }
}
