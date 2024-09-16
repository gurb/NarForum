using Application.Features.Logo.Commands.AddLogo;
using Application.Features.Logo.Queries.GetLogo;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class LogoProfile : Profile
    {
        public LogoProfile()
        {
            CreateMap<LogoDTO, Logo>().ReverseMap();
            CreateMap<AddLogoCommand, Logo>().ReverseMap();
        }
    }
}
