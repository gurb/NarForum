using Application.Contracts.Persistence;
using Application.Features.StaticPage.Queries.GetStaticPages;
using AutoMapper;
using MediatR;

namespace Application.Features.StaticPage.Queries.GetStaticPage
{
    public class GetStaticPageQueryHandler : IRequestHandler<GetStaticPageQuery, StaticPageDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPageRepository _pageRepository;

        public GetStaticPageQueryHandler(IMapper mapper, IPageRepository pageRepository)
        {
            _mapper = mapper;
            _pageRepository = pageRepository;
        }

        public async Task<StaticPageDTO> Handle(GetStaticPageQuery request, CancellationToken cancellationToken)
        {

            Domain.StaticPage? page = null;
            if(request.Id is not null )
            {
                page = await _pageRepository.GetByIdAsync(request.Id.Value);
            }
            else if(request.Url is not null)
            {
                page = await _pageRepository.GetStaticPageByUrl(request.Url);
            }
            return _mapper.Map<StaticPageDTO>(page);
        }
    }
}
