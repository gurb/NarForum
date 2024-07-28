using Application.Features.Post.Queries.GetPostsWithPagination;
using Domain;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence
{
    public interface IPostRepository : IGenericRepository<Post> 
    {
        Task<Post?> GetLastPost(Guid headingId);
        Task<List<Post>> GetPostsByHeadingId(Guid headingId);

        int GetPostsCountByHeadingId(Guid headingId);
        int GetPostsCountByUserName(string userName);

        int GetPostsCount(Expression<Func<Post, bool>> predicate);
        Task<List<Post>> GetPostsWithPagination(Expression<Func<Post, bool>> predicate, int pageIndex, int pageSize);

        Task<List<Post>> GetPostsByHeadingIdWithPagination(Guid headingId, int pageIndex, int pageSize);
        Task<List<Post>> GetPostsByUserNameWithPagination(string userName, int pageIndex, int pageSize);
    }
}
