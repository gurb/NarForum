using NarForumAdmin.Models;
using NarForumAdmin.Models.Heading;
using NarForumAdmin.Models.Post;
using NarForumAdmin.Services.Base;

namespace NarForumAdmin.Contracts
{
    public interface IPostService
    {
        // queries
        Task<List<PostVM>> GetPosts();
        Task<List<PostVM>> GetPostsByHeadingId(Guid id);

        Task<PostsPaginationVM> GetPostsWithPagination(PostPaginationQueryVM query);

        Task<PostsPaginationVM> GetPostsByHeadingIdWithPagination(Guid id, int pageIndex, int pageSize);
        Task<PostsPaginationVM> GetPostsByUserNameWithPagination(string userName, int pageIndex, int pageSize);



        // commands
        Task<ApiResponseVM> CreatePost(PostVM post);
        Task RemovePost(RemovePostCommandVM post);

    }
}
