using Domain;

namespace Application.Contracts.Persistence
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetByName(string name);
        Task<Category> GetByIntId(int id);
        Task IncreaseHeadingCounter(Guid categoryId);
        Task IncreasePostCounter(Guid HeadingId);
        Task UpdateCategoryWhenCreatePost(Guid categoryId, string lastUserName, Guid lastHeadingId, Guid lastPostId);
    }
}
