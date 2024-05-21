using AdminUI.Models.Heading;
using AdminUI.Services.Base;

namespace AdminUI.Contracts
{
    public interface IHeadingService
    {
        // queries
        Task<HeadingVM> GetHeadingById(int id);
        Task<List<HeadingVM>> GetHeadings();
        Task<List<HeadingVM>> GetHeadingsByCategoryName(string name);
        Task<List<HeadingVM>> GetHeadingsByCategoryId(int id);
        Task<HeadingsPaginationVM> GetHeadingsWithPagination(HeadingPaginationQueryVM query);
        Task<HeadingsPaginationVM> GetHeadingsByCategoryNameWithPagination(string categoryName, int pageIndex, int pageSize);
        Task<HeadingsPaginationVM> GetHeadingsByUserNameWithPagination(string userName, int pageIndex, int pageSize);

        // commands
        Task<ApiResponse<Guid>> CreateHeading(HeadingVM heading);
    }
}
