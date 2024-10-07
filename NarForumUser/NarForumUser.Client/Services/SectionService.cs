using AutoMapper;
using NarForumUser.Client.Contracts;
using NarForumUser.Client.Models;
using NarForumUser.Client.Models.Section;
using NarForumUser.Client.Services.Base;
using NarForumUser.Client.Services.Common;

namespace NarForumUser.Client.Services;

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
        var sections = await _client.SectionsAllAsync();
        var data = _mapper.Map<List<SectionVM>>(sections);

        return data;
    }

    public async Task<ApiResponseVM> UpdateSection(SectionVM section)
    {
        var updateSectionCommand = _mapper.Map<UpdateSectionCommand>(section);
        var response = await _client.UpdateSectionAsync(updateSectionCommand);

        var responseVM = _mapper.Map<ApiResponseVM>(response);

        return responseVM;
    }
}
