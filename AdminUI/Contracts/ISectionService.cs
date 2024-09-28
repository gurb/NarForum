using AdminUI.Models;
using AdminUI.Models.Heading;
using AdminUI.Models.Section;
using AdminUI.Services.Base;

namespace AdminUI.Contracts
{
    public interface ISectionService
    {
        // queries
        Task<List<SectionVM>> GetSections();
        Task<SectionPaginationVM> GetSectionsWithPagination(SectionPaginationQueryVM paramQuery);

        // commands
        Task<ApiResponse<Guid>> CreateSection(SectionVM post);
        Task<ApiResponseVM> UpdateSection(SectionVM section);


        Task RemoveSection(RemoveSectionCommandVM section);

    }
}
