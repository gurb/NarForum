using GurbForumUser.Client.Models;
using GurbForumUser.Client.Models.Heading;
using GurbForumUser.Client.Models.Post;
using GurbForumUser.Client.Services.Base;

namespace GurbForumUser.Client.Contracts
{
    public interface IHeadingService
    {
        // queries
        Task<HeadingVM> GetHeadingById(Guid id);
        Task<List<HeadingVM>> GetHeadings();
        Task<List<HeadingVM>> GetHeadingsByCategoryName(string name);
        Task<List<HeadingVM>> GetHeadingsByCategoryId(Guid categoryId);
        Task<HeadingsPaginationVM> GetHeadingsWithPagination(GetHeadingsWithPaginationQueryVM query);
        Task<HeadingsPaginationVM> GetHeadingsByCategoryIdWithPagination(Guid categoryId, int pageIndex, int pageSize);
        Task<HeadingsPaginationVM> GetHeadingsByUserNameWithPagination(string userName, int pageIndex, int pageSize);

        // commands
        Task<ApiResponse<Guid>> CreateHeading(HeadingVM heading);
        Task<ApiResponseVM> LockHeading(LockHeadingCommandVM command);
        Task<ApiResponseVM> PinHeading(PinHeadingCommandVM command);

    }
}
