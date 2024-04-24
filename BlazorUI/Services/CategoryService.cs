using BlazorUI.Contracts;
using BlazorUI.Services.Base;
using BlazorUI.Services.Common;

namespace BlazorUI.Services
{
    public class CategoryService : BaseHttpService, ICategoryService
    {
        public CategoryService(IClient client, LocalStorageService localStorage) : base(client, localStorage)
        {

        }
    }
}
