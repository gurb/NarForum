using AdminUI.Models.Heading;
using AdminUI.Models.Post;
using AdminUI.Services.Base;

namespace AdminUI.Contracts
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
        Task<ApiResponse<Guid>> CreatePost(PostVM post);
        Task RemovePost(RemovePostCommandVM post);

    }
}
