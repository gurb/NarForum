using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class HeadingRepository : GenericRepository<Heading>, IHeadingRepository
    {
        public HeadingRepository(ForumDbContext context) : base(context)
        {

        }

        public async Task<Heading?> GetHeadingById(int? HeadingId)
        {
            return await _context.Headings.AsNoTracking().FirstOrDefaultAsync(x => x.Id == HeadingId);
        }

        public async Task<List<Heading>> GetHeadingsByCategoryIdWithPagination(int categoryId, int pageIndex, int pageSize)
        {
            var totalCount = _context.Headings.AsNoTracking().Count();

            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            var productsPerPage = await _context.Headings.AsNoTracking()
                .Where(x => x.CategoryId == categoryId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return productsPerPage;
        }

        public int GetHeadingsCountByCategoryId(int categoryId)
        {
            var totalCount = _context.Headings.AsNoTracking().Where(x => x.CategoryId == categoryId).Count();
            return totalCount;
        }
    }
}
