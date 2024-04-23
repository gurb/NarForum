using Blazored.LocalStorage;
using BlazorUI.Contracts;
using BlazorUI.Services.Base;

namespace BlazorUI.Services
{
    public class HeadingService : BaseHttpService, IHeadingService
    {
        public HeadingService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {

        }
    }
}
