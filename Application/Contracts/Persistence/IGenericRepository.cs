using Domain.Base;

namespace Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);
    }
}
