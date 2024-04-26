using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ForumDbContext context) : base(context)
        {

        }

        public async Task<Category> GetByName(string name)
        {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
