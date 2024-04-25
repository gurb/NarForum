using BlazorUI.Models.Section;
using BlazorUI.Services.Base;

namespace BlazorUI.Contracts
{
    public interface ISectionService
    {

        // queries
        Task<List<SectionVM>> GetSections();

        // commands
        Task<ApiResponse<Guid>> CreateSection(SectionVM post);

        
    }
}
