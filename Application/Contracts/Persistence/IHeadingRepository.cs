using Domain;
using System.Runtime.InteropServices;

namespace Application.Contracts.Persistence
{
    public interface IHeadingRepository: IGenericRepository<Heading> 
    {
        Task<Heading?> GetHeadingById(string? HeadingId);

        Task<List<Heading>> GetHeadingsWithPagination(int pageIndex, int pageSize);
        Task<List<Heading>> GetHeadingsByCategoryIdWithPagination(string categoryId, int pageIndex, int pageSize);
        Task<List<Heading>> GetHeadingsByUserNameWithPagination(string userName, int pageIndex, int pageSize);

        int GetHeadingsCountByCategoryId(string categoryId);
        int GetHeadingsCountByUserName(string userName);

        Task IncreasePostCounter(string HeadingId);
        Task UpdateHeadingWhenCreatePost(string headingId, string lastUserName, string lastPostId);
    }
}
