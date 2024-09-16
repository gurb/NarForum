using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Logo.Queries.GetLogo
{
    public class GetLogoQueryHandler : IRequestHandler<GetLogoQuery, LogoDTO>
    {

        private readonly IMapper _mapper;
        private readonly ILogoService _logoService;

        public GetLogoQueryHandler(IMapper mapper, ILogoService logoService)
        {
            _mapper = mapper;
            _logoService = logoService;
        }

        public async Task<LogoDTO> Handle(GetLogoQuery request, CancellationToken cancellationToken)
        {
            var logo = await _logoService.GetAsync();

            if(logo != null)
            {
                return _mapper.Map<LogoDTO>(logo);
            }
            else
            {
                return new LogoDTO();
            }
        }
    }
}
