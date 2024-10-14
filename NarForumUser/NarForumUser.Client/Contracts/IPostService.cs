using NarForumUser.Client.Models;
using NarForumUser.Client.Models.Post;

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
        Task<ApiResponseVM> CreatePost(PostVM post);
    }
}
