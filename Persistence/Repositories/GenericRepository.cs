using Application.Contracts.Persistence;
using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System.Linq.Expressions;


namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ForumDbContext _context;

        public GenericRepository(ForumDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateListAsync(List<T> entities)
        {
			await _context.AddRangeAsync(entities);
			await _context.SaveChangesAsync();
		}

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate, bool isTrack = false)
        {

            if(isTrack)
            {
                return await _context.Set<T>().Where(predicate).ToListAsync();
            }
            else
            {
                return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
            }
        }

        public async Task<List<T>> GetAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id, bool isTrack=false)
        {
            if(isTrack)
            {
                return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            }
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetWithPagination(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize)
        {
            var productsPerPage = await _context.Set<T>().AsNoTracking()
                .Where(predicate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return productsPerPage;
        }

        public int GetCount(Expression<Func<T, bool>> predicate)
        {
            return  _context.Set<T>().AsNoTracking().Where(predicate).Count();
        }

        public async Task<T?> GetByIdAsyncWithTrack(string id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void UpdateList(List<T> Entities)
        {
            _context.Set<T>().UpdateRange(Entities);
            _context.SaveChanges();
        }
    }
}
