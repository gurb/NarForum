using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System.Linq;
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

        public async Task<Favorite?> GetAsync(Expression<Func<Favorite, bool>> predicate)
        {
            return await _context.Favorites.FirstOrDefaultAsync(predicate);
        }

        public int GetCount(Expression<Func<Favorite, bool>> predicate)
        {
            return _context.Favorites.AsNoTracking().Where(predicate).Count();
        }

        public async Task<List<Favorite>> GetFavoritesWithPagination(Expression<Func<Favorite, bool>> predicate, int pageIndex, int pageSize)
        {
            var favorites = await _context.Favorites.AsNoTracking()
                .Where(predicate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return favorites;
        }
    }
}
