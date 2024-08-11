using Domain;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence;

public interface IBlogPostRepository : IGenericRepository<BlogPost>
{
	Task<BlogPost?> GetByIdWithBlogCategoryAsync(Guid id, bool isTrack = false);
    Task<List<BlogPost>> GetBlogPostsWithPaginationIncludeBlogCategory(Expression<Func<BlogPost, bool>> predicate, int pageIndex, int pageSize);
}
