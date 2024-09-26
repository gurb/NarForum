using Domain.Base;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(Guid id, bool isTrack = false);
        Task<T?> GetByIdAsyncWithTrack(Guid id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task CreateAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);
        Task CreateListAsync(List<T> Entities);
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate, bool isTrack = false);
        int GetCount(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetWithPagination(Expression<Func<T, bool>> predicate, int pageIndex, int pageSize, Dictionary<string, bool>? orderFunctions = null);
        void UpdateList(List<T> Entities);
    }
}
