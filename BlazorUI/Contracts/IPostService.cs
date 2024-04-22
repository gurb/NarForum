using BlazorUI.Models.Post;
using BlazorUI.Services.Base;

namespace BlazorUI.Contracts
{
    public interface IPostService
    {

        // queries
        Task<List<PostVM>> GetPosts();

        // commands
        Task<ApiResponse<Guid>> CreatePost(PostVM post);
    }
}
