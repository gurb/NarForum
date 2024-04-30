using Domain;
using System.Runtime.InteropServices;

namespace Application.Contracts.Persistence
{
    public interface IHeadingRepository: IGenericRepository<Heading> 
    {
        Task<Heading?> GetHeadingById(int? HeadingId);
        Task<List<Heading>> GetHeadingsByCategoryIdWithPagination(int categoryId, int pageIndex, int pageSize);
        Task<List<Heading>> GetHeadingsByUserNameWithPagination(string userName, int pageIndex, int pageSize);

        int GetHeadingsCountByCategoryId(int categoryId);
        int GetHeadingsCountByUserName(string userName);

    }
}
