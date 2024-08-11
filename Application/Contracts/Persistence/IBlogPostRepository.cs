using Domain;

namespace Application.Contracts.Persistence;

public interface IBlogPostRepository : IGenericRepository<BlogPost>
{
	Task<BlogPost?> GetByIdWithBlogCategoryAsync(Guid id, bool isTrack = false);
}
