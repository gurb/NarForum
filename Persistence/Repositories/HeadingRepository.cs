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

        public async Task<Heading?> GetHeadingById(Guid HeadingId)
        {
            return await _context.Headings.AsNoTracking().FirstOrDefaultAsync(x => x.Id == HeadingId);
        }

        public async Task<List<Heading>> GetHeadingsByCategoryIdWithPagination(Guid categoryId, int pageIndex, int pageSize)
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

        public async Task<List<Heading>> GetHeadingsByUserNameWithPagination(string userName, int pageIndex, int pageSize)
        {
            var totalCount = _context.Headings.AsNoTracking().Count();

            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            var productsPerPage = await _context.Headings.AsNoTracking()
                .Where(x => x.UserName == userName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return productsPerPage; ;
        }

        public int GetHeadingsCountByCategoryId(Guid categoryId)
        {
            var totalCount = _context.Headings.AsNoTracking().Where(x => x.CategoryId == categoryId).Count();
            return totalCount;
        }

        public int GetHeadingsCountByUserName(string userName)
        {
            var totalCount = _context.Headings.AsNoTracking().Where(x => x.UserName == userName).Count();
            return totalCount;
        }

        public async Task<List<Heading>> GetHeadingsWithPagination(int pageIndex, int pageSize)
        {
            var productsPerPage = await _context.Headings.AsNoTracking()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return productsPerPage;
        }

        public async Task IncreasePostCounter(Guid HeadingId)
        {
            var heading = await _context.Headings.FirstOrDefaultAsync(x => x.Id == HeadingId);

            if (heading != null)
            {
                heading.PostCounter++;

                _context.Update(heading);
                _context.Entry(heading).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateHeadingWhenCreatePost(Guid headingId, string lastUserName, Guid lastPostId)
        {
            var heading = await _context.Headings.FirstOrDefaultAsync(x => x.Id == headingId);

            if (heading != null)
            {
                heading.LastPostId = lastPostId;
                heading.ActiveDate = DateTime.UtcNow;
                heading.LastUserName = lastUserName;

                _context.Update(heading);
                _context.Entry(heading).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
