using AdminUI.Models.Section;
using AdminUI.Services.Base;

namespace AdminUI.Contracts
{
    public interface ISectionService
    {
        // queries
        Task<List<SectionVM>> GetSections();

        // commands
        Task<ApiResponse<Guid>> CreateSection(SectionVM post);

    }
}
