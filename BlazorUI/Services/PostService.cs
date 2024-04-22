using BlazorUI.Contracts;
using BlazorUI.Services.Base;

namespace BlazorUI.Services
{
    public class PostService: BaseHttpService, IPostService
    {
        public PostService(IClient client) : base(client) 
        {
        
        }
    }
}
