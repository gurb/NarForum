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

        public async Task<T> GetByIdAsync(Guid id, bool isTrack=false)
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

        public async Task<List<T>> GetWithPagination(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize, string? propertyName, bool desc = true)
        {
            List<T>? productsPerPage; 
            if(propertyName is not null)
            {
                IQueryable<T> query = _context.Set<T>().AsNoTracking().Where(predicate);

                query = ApplyOrder(query, propertyName, desc);

                productsPerPage = await query
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            else
            {
                productsPerPage = await _context.Set<T>().AsNoTracking()
                    .Where(predicate)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                .ToListAsync();
            }

            return productsPerPage;
        }

        public int GetCount(Expression<Func<T, bool>> predicate)
        {
            return  _context.Set<T>().AsNoTracking().Where(predicate).Count();
        }

        public async Task<T?> GetByIdAsyncWithTrack(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void UpdateList(List<T> Entities)
        {
            _context.Set<T>().UpdateRange(Entities);
            _context.SaveChanges();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().Where(predicate).AnyAsync();
        }

        public static IQueryable<T> ApplyOrder<T>(IQueryable<T> source, string sortProperty, bool descending)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, sortProperty);
            var propertyType = property.Type;
            var convertedProperty = Expression.Convert(property, typeof(object));
            var sortExpression = Expression.Lambda<Func<T, object>>(convertedProperty, parameter);

            var methodName = descending ? "OrderByDescending" : "OrderBy";
            var method = typeof(Queryable).GetMethods()
                .Where(m => m.Name == methodName && m.GetParameters().Length == 2)
                .Single()
                .MakeGenericMethod(typeof(T), typeof(object));

            var resultExpression = Expression.Call(
                method,
                source.Expression,
                sortExpression
            );

            return source.Provider.CreateQuery<T>(resultExpression);
        }

    }
}
