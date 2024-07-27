using Application.Features.Post.Queries.GetPostsWithPagination;
using Domain;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence
{
    public interface IPostRepository : IGenericRepository<Post> 
    {
        Task<Post?> GetLastPost(string? headingId);
        Task<List<Post>> GetPostsByHeadingId(string headingId);

        int GetPostsCountByHeadingId(string headingId);
        int GetPostsCountByUserName(string userName);

        int GetPostsCount(Expression<Func<Post, bool>> predicate);
        Task<List<Post>> GetPostsWithPagination(Expression<Func<Post, bool>> predicate, int pageIndex, int pageSize);

        Task<List<Post>> GetPostsByHeadingIdWithPagination(string headingId, int pageIndex, int pageSize);
        Task<List<Post>> GetPostsByUserNameWithPagination(string userName, int pageIndex, int pageSize);
    }
}
