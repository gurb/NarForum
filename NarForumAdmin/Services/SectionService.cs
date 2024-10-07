using AutoMapper;
using NarForumAdmin.Contracts;
using NarForumAdmin.Models.Section;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using NarForumAdmin.Models.Category;
using NarForumAdmin.Models;

namespace NarForumAdmin.Services;

public class SectionService : BaseHttpService, ISectionService
{
    private readonly IMapper _mapper;

    public SectionService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
    {
        _mapper = mapper;
    }

    public async Task<ApiResponse<Guid>> CreateSection(SectionVM section)
    {
        try
        {
            var createSectionCommand = _mapper.Map<CreateSectionCommand>(section);
            await _client.SectionsAsync(createSectionCommand);
            return new ApiResponse<Guid>
            {
                Success = true
            };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<List<SectionVM>> GetSections()
    {
        try
        {
            var sections = await _client.SectionsAllAsync();
            var data = _mapper.Map<List<SectionVM>>(sections);

            return data;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<SectionPaginationVM> GetSectionsWithPagination(SectionPaginationQueryVM paramQuery)
    {
        try
        {
            GetSectionsWithPaginationQuery query = _mapper.Map<GetSectionsWithPaginationQuery>(paramQuery);

            var sectionsPagination = await _client.GetSectionsWithPaginationAsync(query);

            var data = _mapper.Map<SectionPaginationVM>(sectionsPagination);

            return data;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task RemoveSection(RemoveSectionCommandVM section)
    {
        
        try
        {
            RemoveSectionCommand command = _mapper.Map<RemoveSectionCommand>(section);
            await _client.RemoveSectionAsync(command);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task<ApiResponseVM> UpdateSection(SectionVM section)
    {
        try
        {
            var updateSectionCommand = _mapper.Map<UpdateSectionCommand>(section);
            var response = await _client.UpdateSectionAsync(updateSectionCommand);

            var responseVM = _mapper.Map<ApiResponseVM>(response);

            return responseVM;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }
}
