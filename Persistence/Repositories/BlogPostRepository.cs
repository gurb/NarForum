using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Persistence.DatabaseContext;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class BlogPostRepository : GenericRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(ForumDbContext context) : base(context)
        {

        }

        public async Task<List<BlogPost>> GetBlogPostsWithPaginationIncludeBlogCategory(Expression<Func<BlogPost, bool>> predicate, int pageIndex, int pageSize, string? propertyName = null, bool desc = true)
        { 
            List<BlogPost>? productsPerPage;
            if (propertyName is not null)
            {
                IQueryable<BlogPost> query = _context.BlogPosts.AsNoTracking().Where(predicate);

                query = ApplyOrder(query, propertyName, desc);

                productsPerPage = await query
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .Include(x => x.BlogCategory)
                    .ToListAsync();
            }
            else
            {
                productsPerPage = await _context.BlogPosts.AsNoTracking()
                    .Where(predicate)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .Include(x => x.BlogCategory)
                    .ToListAsync();
            }

            return productsPerPage;
        }

        public async Task<BlogPost?> GetByIdWithBlogCategoryAsync(Guid id, bool isTrack = false)
		{
			if (isTrack)
			{
				return await _context.BlogPosts.Include(x => x.BlogCategory).FirstOrDefaultAsync(x => x.Id == id);
			}
			return await _context.BlogPosts.AsNoTracking().Include(x => x.BlogCategory).FirstOrDefaultAsync(x => x.Id == id);
		}

        public async Task<BlogPost?> GetByIntIdWithBlogCategoryAsync(int id, bool isTrack = false)
        {
            if (isTrack)
            {
                return await _context.BlogPosts.Include(x => x.BlogCategory).FirstOrDefaultAsync(x => x.BlogPostId == id);
            }
            return await _context.BlogPosts.AsNoTracking().Include(x => x.BlogCategory).FirstOrDefaultAsync(x => x.BlogPostId == id);
        }
    }
}
