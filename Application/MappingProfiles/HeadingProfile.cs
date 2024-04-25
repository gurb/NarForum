using Application.Features.Heading.Commands.CreateHeading;
using Application.Features.Heading.Queries;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class HeadingProfile : Profile
    {
        public HeadingProfile()
        {
            CreateMap<HeadingDTO, Heading>().ReverseMap();
            CreateMap<CreateHeadingCommand, Heading>().ReverseMap();
        }
    }
}
