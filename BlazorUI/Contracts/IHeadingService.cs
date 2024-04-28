using BlazorUI.Models.Heading;
using BlazorUI.Models.Post;
using BlazorUI.Services.Base;

namespace BlazorUI.Contracts
{
    public interface IHeadingService
    {
        // queries
        Task<List<HeadingVM>> GetHeadings();
        Task<List<HeadingVM>> GetHeadingsByCategoryName(string name);
        Task<List<HeadingVM>> GetHeadingsByCategoryId(int id);
        Task<HeadingsPaginationVM> GetHeadingsByCategoryNameWithPagination(string categoryName, int pageIndex, int pageSize);

        // commands
        Task<ApiResponse<Guid>> CreateHeading(HeadingVM heading);
    }
}
