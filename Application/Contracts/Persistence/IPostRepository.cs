using Application.Features.Post.Queries.GetPostsWithPagination;
using Domain;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence
{
    public interface IPostRepository : IGenericRepository<Post> 
    {
        Task<Post?> GetLastPost(int? headingId);
        Task<List<Post>> GetPostsByHeadingId(int headingId);

        int GetPostsCountByHeadingId(int headingId);
        int GetPostsCountByUserName(string userName);

        int GetPostsCount(Expression<Func<Post, bool>> predicate);
        Task<List<Post>> GetPostsWithPagination(Expression<Func<Post, bool>> predicate, int pageIndex, int pageSize);

        Task<List<Post>> GetPostsByHeadingIdWithPagination(int headingId, int pageIndex, int pageSize);
        Task<List<Post>> GetPostsByUserNameWithPagination(string userName, int pageIndex, int pageSize);
    }
}
