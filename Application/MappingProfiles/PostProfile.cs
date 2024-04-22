using Application.Features.Post.Commands.CreatePost;
using Application.Features.Post.Queries.GetAllPosts;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostDTO, Post>().ReverseMap();
            CreateMap<CreatePostCommand, Post>().ReverseMap(); ;
        }
    }
}
