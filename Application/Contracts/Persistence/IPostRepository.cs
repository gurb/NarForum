using Domain;

namespace Application.Contracts.Persistence
{
    public interface IPostRepository : IGenericRepository<Post> 
    { 
        Task<List<Post>> GetPostsByHeadingId(int headingId);

        int GetPostsCountByHeadingId(int headingId);

        Task<List<Post>> GetPostsByHeadingIdWithPagination(int headingId, int pageIndex, int pageSize);
    }
}
