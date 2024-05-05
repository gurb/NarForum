using Domain;

namespace Application.Contracts.Persistence
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetByName(string name);
        Task IncreaseHeadingCounter(int categoryId);
        Task IncreasePostCounter(int HeadingId);
    }
}
