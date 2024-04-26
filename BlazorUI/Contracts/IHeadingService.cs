using BlazorUI.Models.Heading;
using BlazorUI.Services.Base;

namespace BlazorUI.Contracts
{
    public interface IHeadingService
    {
        // queries
        Task<List<HeadingVM>> GetHeadings();
        Task<List<HeadingVM>> GetHeadingsByCategoryName(string name);
        Task<List<HeadingVM>> GetHeadingsByCategoryId(int id);

        // commands
        Task<ApiResponse<Guid>> CreateHeading(HeadingVM post);
    }
}
