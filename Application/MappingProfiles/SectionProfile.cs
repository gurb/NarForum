using Application.Features.Section.Commands.CreateSection;
using Application.Features.Section.Queries.GetSections;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<SectionDTO, Section>().ReverseMap();
            CreateMap<CreateSectionCommand, Section>().ReverseMap();
        }
    }
}
