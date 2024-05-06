using Application.Features.Like.Commands.AddLike;
using Application.Features.Like.Queries.GetLikes;
using AutoMapper;
using Domain;


namespace Application.MappingProfiles
{
    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            CreateMap<LikeDTO, Like>().ReverseMap();
            CreateMap<AddLikeCommand, Like>().ReverseMap();
        }
    }
}
