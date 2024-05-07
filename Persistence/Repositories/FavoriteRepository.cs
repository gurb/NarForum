using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        protected readonly ForumDbContext _context;

        public FavoriteRepository(ForumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Favorite Entity)
        {
            await _context.AddAsync(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Favorite entity)
        {
            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Favorite entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Favorite>> GetAllAsync(Expression<Func<Favorite, bool>> predicate)
        {
            return await _context.Favorites.AsNoTracking().Where(predicate).ToListAsync();
        }
    }
}
