using Domain;

namespace Application.Contracts.Persistence
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetByName(string name);
        Task IncreaseHeadingCounter(string categoryId);
        Task IncreasePostCounter(string HeadingId);
        Task UpdateCategoryWhenCreatePost(string categoryId, string lastUserName, string lastHeadingId, string lastPostId);
    }
}
