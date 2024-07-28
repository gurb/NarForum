using AdminUI.Models.Heading;
using AdminUI.Models.Post;
using AdminUI.Services.Base;

namespace AdminUI.Contracts
{
    public interface IPostService
    {
        // queries
        Task<List<PostVM>> GetPosts();
        Task<List<PostVM>> GetPostsByHeadingId(string id);

        Task<PostsPaginationVM> GetPostsWithPagination(PostPaginationQueryVM query);

        Task<PostsPaginationVM> GetPostsByHeadingIdWithPagination(string id, int pageIndex, int pageSize);
        Task<PostsPaginationVM> GetPostsByUserNameWithPagination(string userName, int pageIndex, int pageSize);



        // commands
        Task<ApiResponse<Guid>> CreatePost(PostVM post);
        Task RemovePost(RemovePostCommandVM post);

    }
}
