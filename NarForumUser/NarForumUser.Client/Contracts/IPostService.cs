using NarForumUser.Client.Models.Post;
using NarForumUser.Client.Services.Base;

namespace NarForumUser.Client.Contracts
{
    public interface IPostService
    {

        // queries
        Task<List<PostVM>> GetPosts();
        Task<List<PostVM>> GetPostsByHeadingId(Guid id);
        Task<PostsPaginationVM> GetPostsByHeadingIdWithPagination(Guid id, int pageIndex, int pageSize);
        Task<PostsPaginationVM> GetPostsByUserNameWithPagination(string userName, int pageIndex, int pageSize);



        // commands
        Task<ApiResponse<Guid>> CreatePost(PostVM post);


    }
}
