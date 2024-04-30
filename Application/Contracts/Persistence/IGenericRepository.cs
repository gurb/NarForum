using Domain.Base;
using System.Linq.Expressions;

namespace Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    }
}
