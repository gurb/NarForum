using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        protected readonly ForumDbContext _context;

        public LikeRepository(ForumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Like Entity)
        {
            await _context.AddAsync(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Like entity)
        {
            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Like entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Like>> GetAllAsync(Expression<Func<Like, bool>> predicate)
        {
            return await _context.Likes.AsNoTracking().Where(predicate).ToListAsync();
        }
    }
}
