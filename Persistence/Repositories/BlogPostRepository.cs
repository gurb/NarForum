using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class BlogPostRepository : GenericRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(ForumDbContext context) : base(context)
        {

        }

		public async Task<BlogPost?> GetByIdWithBlogCategoryAsync(Guid id, bool isTrack = false)
		{
			if (isTrack)
			{
				return await _context.BlogPosts.Include(x => x.BlogCategory).FirstOrDefaultAsync(x => x.Id == id);
			}
			return await _context.BlogPosts.AsNoTracking().Include(x => x.BlogCategory).FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
