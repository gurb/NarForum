using NarForumAdmin.Models;
using NarForumAdmin.Models.Category;
using NarForumAdmin.Models.Heading;
using NarForumAdmin.Services.Base;

namespace NarForumAdmin.Contracts
{
    public interface IHeadingService
    {
        // queries
        Task<HeadingVM> GetHeadingById(Guid id);
        Task<List<HeadingVM>> GetHeadings();
        Task<List<HeadingVM>> GetHeadingsByCategoryName(string name);
        Task<List<HeadingVM>> GetHeadingsByCategoryId(Guid categoryId);
        Task<HeadingsPaginationVM> GetHeadingsWithPagination(HeadingPaginationQueryVM query);
        Task<HeadingsPaginationVM> GetHeadingsByCategoryIdWithPagination(Guid categoryId, int pageIndex, int pageSize);
        Task<HeadingsPaginationVM> GetHeadingsByUserNameWithPagination(string userName, int pageIndex, int pageSize);

        // commands
        Task<ApiResponse<Guid>> CreateHeading(HeadingVM heading);
        Task RemoveHeading(RemoveHeadingCommandVM heading);
        Task<ApiResponseVM> LockHeading(LockHeadingCommandVM command);
        Task<ApiResponseVM> PinHeading(PinHeadingCommandVM command);
        Task<ApiResponseVM> UpdateHeading(UpdateHeadingCommandVM command);

    }
}
