using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class TrackingLogRepository : ITrackingLogRepository
    {
        protected readonly ForumDbContext _context;

        public TrackingLogRepository(ForumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TrackingLog Entity)
        {
            await _context.AddAsync(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TrackingLog, bool>> predicate)
        {
            return await _context.TrackingLogs.AsNoTracking().Where(predicate).AnyAsync();
        }

        public async Task DeleteAsync(TrackingLog Entity)
        {
            _context.Remove(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TrackingLog>> GetAllAsync(Expression<Func<TrackingLog, bool>> predicate)
        {
            return await _context.TrackingLogs.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TrackingLog> GetAsync(Expression<Func<TrackingLog, bool>> predicate)
        {
            return await _context.TrackingLogs.FirstOrDefaultAsync(predicate);
        }

		public int GetCount(Expression<Func<TrackingLog, bool>> predicate)
		{
			return _context.TrackingLogs.AsNoTracking().Where(predicate).Count();
		}

		public async Task<List<TrackingLog>> GetWithPagination(Expression<Func<TrackingLog, bool>> predicate, int pageIndex, int pageSize)
		{
			var productsPerPage = await _context.TrackingLogs.AsNoTracking()
				.Where(predicate)
				.Skip((pageIndex - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			return productsPerPage;
		}

		public async Task UpdateAsync(TrackingLog Entity)
        {
            _context.Update(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}