using Application.Features.ForumSetting.Commands.UpdateForumSettings;
using Application.Features.ForumSetting.Queries.GetForumSettings;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class ForumSettingsProfile : Profile
    {
        public ForumSettingsProfile()
        {
            CreateMap<ForumSettingsDTO, ForumSettings>().ReverseMap();
            CreateMap<UpdateForumSettingsCommand, ForumSettings>().ReverseMap();
        }
    }
}
