using Application.Contracts.Persistence;
using Application.Extensions.Core;
using AutoMapper;
using MediatR;

namespace Application.Features.StaticPage.Queries.GetStaticPages;

public class GetStaticPagesQueryHandler : IRequestHandler<GetStaticPagesQuery, List<StaticPageDTO>>
{
    private readonly IMapper _mapper;
    private readonly IPageRepository _pageRepository;

    public GetStaticPagesQueryHandler(IMapper mapper, IPageRepository pageRepository)
    {
        _mapper = mapper;
        _pageRepository = pageRepository;
    }

    public async Task<List<StaticPageDTO>> Handle(GetStaticPagesQuery request, CancellationToken cancellationToken)
    {

        var predicate = PredicateBuilder.True<Domain.StaticPage>();

        predicate = predicate.And(x => x.IsActive);

        var staticPages = await _pageRepository.GetAllAsync(predicate);

        var data = _mapper.Map<List<StaticPageDTO>>(staticPages);

        return data;
    }
}
