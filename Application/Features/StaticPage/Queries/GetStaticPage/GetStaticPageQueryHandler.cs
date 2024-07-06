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
            var staticPage = await _pageRepository.GetByIdAsync(request.Id);

            var data = _mapper.Map<StaticPageDTO>(staticPage);

            return data;
        }
    }
}
