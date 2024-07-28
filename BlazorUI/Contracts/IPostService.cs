using BlazorUI.Models.Post;
using BlazorUI.Services.Base;

namespace BlazorUI.Contracts
{
    public interface IPostService
    {

        // queries
        Task<List<PostVM>> GetPosts();
        Task<List<PostVM>> GetPostsByHeadingId(string id);
        Task<PostsPaginationVM> GetPostsByHeadingIdWithPagination(string id, int pageIndex, int pageSize);
        Task<PostsPaginationVM> GetPostsByUserNameWithPagination(string userName, int pageIndex, int pageSize);



        // commands
        Task<ApiResponse<Guid>> CreatePost(PostVM post);


    }
}
