using Domain.Base;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task<T?> GetByIdAsyncWithTrack(int id);
        Task CreateAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);
        Task CreateListAsync(List<T> Entities);
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        int GetCount(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetWithPagination(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize);
    }
}
