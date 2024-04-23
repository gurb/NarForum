using Blazored.LocalStorage;
using BlazorUI.Contracts;
using BlazorUI.Services.Base;

namespace BlazorUI.Services
{
    public class CategoryService : BaseHttpService, ICategoryService
    {
        public CategoryService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {

        }
    }
}
