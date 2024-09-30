using Domain;
using System.Runtime.InteropServices;

namespace Application.Contracts.Persistence
{
    public interface IHeadingRepository: IGenericRepository<Heading> 
    {
        Task<Heading?> GetHeadingById(Guid HeadingId);

        Task<List<Heading>> GetHeadingsWithPagination(int pageIndex, int pageSize);
        Task<List<Heading>> GetHeadingsByCategoryIdWithPagination(Guid categoryId, int pageIndex, int pageSize);
        Task<List<Heading>> GetHeadingsByUserNameWithPagination(string userName, int pageIndex, int pageSize);

        int GetHeadingsCountByCategoryId(Guid categoryId);
        int GetHeadingsCountByUserName(string userName);

        Task IncreasePostCounter(Guid HeadingId);
        Task UpdateHeadingWhenCreatePost(Guid headingId, string lastUserName, Guid lastUserId, Guid lastPostId);
    }
}
