﻿using AutoMapper;
using AdminUI.Contracts;
using AdminUI.Models.Section;
using AdminUI.Services.Base;
using AdminUI.Services.Common;

namespace AdminUI.Services;

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
}