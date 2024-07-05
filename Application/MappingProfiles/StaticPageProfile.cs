using Application.Features.StaticPage.Commands.CreateStaticPage;
using Application.Features.StaticPage.Queries.GetStaticPages;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class StaticPageProfile: Profile
    {
        public StaticPageProfile()
        {
            CreateMap<StaticPageDTO, StaticPage>().ReverseMap();
            CreateMap<CreateStaticPageCommand, StaticPage>().ReverseMap();
        }
    }
}
