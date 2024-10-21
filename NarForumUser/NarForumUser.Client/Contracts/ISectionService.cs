using NarForumUser.Client.Models;
using NarForumUser.Client.Models.Section;
using NarForumUser.Client.Services.Base;

namespace NarForumUser.Client.Contracts
{
    public interface ISectionService
    {

        // queries
        Task<List<SectionVM>> GetSections();

        // commands
        Task<ApiResponseVM> CreateSection(SectionVM section);

        Task<ApiResponseVM> UpdateSection(SectionVM section);

        
    }
}
