using Domain.Base;

namespace Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T Entity);
        Task<T> UpdateAsync(T Entity);
        Task<T> DeleteAsync(T Entity);
    }
}
