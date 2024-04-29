﻿using Application.Contracts.Persistence;
using Application.Features.Post.Queries.GetAllPosts;
using AutoMapper;
using MediatR;

namespace Application.Features.Section.Queries.GetSections;

public class GetSectionsQueryHandler: IRequestHandler<GetSectionsQuery, List<SectionDTO>>
{
    private readonly IMapper _mapper;
    private readonly ISectionRepository _sectionRepository;

    public GetSectionsQueryHandler(IMapper mapper, ISectionRepository sectionRepository)
    {
        _mapper = mapper;
        _sectionRepository = sectionRepository;
    }

    public async Task<List<SectionDTO>> Handle(GetSectionsQuery request, CancellationToken cancellationToken)
    {
        // query the database
        try
        {
            var sections = await _sectionRepository.GetAsync();
            var data = _mapper.Map<List<SectionDTO>>(sections);

            // return list of DTOs
            return data;
        }
        catch (Exception ex)
        {
            var message = ex.Message;   
        }
        return null;

        // convert data objecs to DTOs
        
    }
}

