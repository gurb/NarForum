using BlazorUI.Models.Heading;
using BlazorUI.Models.Post;
using BlazorUI.Services.Base;

namespace BlazorUI.Contracts
{
    public interface IHeadingService
    {
        // queries
        Task<HeadingVM> GetHeadingById(string id);
        Task<List<HeadingVM>> GetHeadings();
        Task<List<HeadingVM>> GetHeadingsByCategoryName(string name);
        Task<List<HeadingVM>> GetHeadingsByCategoryId(string id);
        Task<HeadingsPaginationVM> GetHeadingsByCategoryNameWithPagination(string categoryName, int pageIndex, int pageSize);
        Task<HeadingsPaginationVM> GetHeadingsByUserNameWithPagination(string userName, int pageIndex, int pageSize);

        // commands
        Task<ApiResponse<Guid>> CreateHeading(HeadingVM heading);
    }
}
