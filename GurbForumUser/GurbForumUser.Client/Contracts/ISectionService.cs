using GurbForumUser.Client.Models;
using GurbForumUser.Client.Models.Section;
using GurbForumUser.Client.Services.Base;

namespace GurbForumUser.Client.Contracts
{
    public interface ISectionService
    {

        // queries
        Task<List<SectionVM>> GetSections();

        // commands
        Task<ApiResponse<Guid>> CreateSection(SectionVM section);

        Task<ApiResponseVM> UpdateSection(SectionVM section);

        
    }
}
