using Domain;

namespace Application.Contracts.Persistence
{
    public interface ILogoService
    {
        Task AddAsync(Logo Entity);
        Task DeleteAsync(Logo Entity);
        Task UpdateAsync(Logo Entity);
        Task<Logo?> GetAsync();
    }
}
