using BlazorUI.Contracts;
using BlazorUI.Services.Base;
using BlazorUI.Services.Common;

namespace BlazorUI.Services
{
    public class HeadingService : BaseHttpService, IHeadingService
    {
        public HeadingService(IClient client, LocalStorageService localStorage) : base(client, localStorage)
        {

        }
    }
}
