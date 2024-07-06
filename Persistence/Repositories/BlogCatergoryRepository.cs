using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class BlogCatergoryRepository : IBlogCategoryRepository
    {

        protected readonly ForumDbContext _context;

        public BlogCatergoryRepository(ForumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BlogCategory Entity)
        {
            await _context.AddAsync(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(BlogCategory Entity)
        {
            _context.Remove(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BlogCategory>> GetAllAsync(Expression<Func<BlogCategory, bool>> predicate)
        {
            return await _context.BlogCategories.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<BlogCategory> GetAsync(Expression<Func<BlogCategory, bool>> predicate)
        {
            return await _context.BlogCategories.FirstOrDefaultAsync(predicate);
        }

        public async Task UpdateAsync(BlogCategory Entity)
        {
            _context.Update(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
