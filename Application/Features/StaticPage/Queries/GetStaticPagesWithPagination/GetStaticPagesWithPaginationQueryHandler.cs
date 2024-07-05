﻿using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.StaticPage.Queries.GetStaticPages;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StaticPage.Queries.GetStaticPagesWithPagination;

public class GetStaticPagesWithPaginationQueryHandler : IRequestHandler<GetStaticPagesWithPaginationQuery, StaticPagesPaginationDTO>
{
    private readonly IMapper _mapper;
    private readonly IPageRepository _pageRepository;

    public GetStaticPagesWithPaginationQueryHandler(IMapper mapper, IPageRepository pageRepository)
    {
        _mapper = mapper;
        _pageRepository = pageRepository;
    }

    public async Task<StaticPagesPaginationDTO> Handle(GetStaticPagesWithPaginationQuery request, CancellationToken cancellationToken)
    { 
        var predicate = PredicateBuilder.True<Domain.StaticPage>();

        var staticPages = await _pageRepository.GetWithPagination(predicate, request.PageIndex!.Value, request.PageSize!.Value);

        var data = _mapper.Map<List<StaticPageDTO>>(staticPages);

        StaticPagesPaginationDTO dto = new StaticPagesPaginationDTO
        {
            StaticPages = data,
            TotalCount = _pageRepository.GetCount(predicate)
        };

        return dto;
    }
}
