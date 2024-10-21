using NarForumAdmin.Models;
using NarForumAdmin.Models.Heading;
using NarForumAdmin.Models.Section;
using NarForumAdmin.Services.Base;

namespace NarForumAdmin.Contracts
{
    public interface ISectionService
    {
        // queries
        Task<List<SectionVM>> GetSections();
        Task<SectionPaginationVM> GetSectionsWithPagination(SectionPaginationQueryVM paramQuery);

        // commands
        Task<ApiResponseVM> CreateSection(SectionVM post);
        Task<ApiResponseVM> UpdateSection(SectionVM section);


        Task RemoveSection(RemoveSectionCommandVM section);

    }
}
