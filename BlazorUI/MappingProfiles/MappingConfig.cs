using AutoMapper;
using BlazorUI.Models.Post;
using BlazorUI.Services.Base;

namespace BlazorUI.MappingProfiles
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<PostDTO, PostVM>().ReverseMap();
            CreateMap<CreatePostCommand, PostVM>().ReverseMap();
        }
    }
}
