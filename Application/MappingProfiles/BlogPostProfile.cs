using Application.Features.BlogPost.Commands.CreateBlogPost;
using Application.Features.BlogPost.Queries.GetBlogPosts;
using AutoMapper;
using Domain;


namespace Application.MappingProfiles;

public class BlogPostProfile:Profile
{
    public BlogPostProfile()
    {
        CreateMap<BlogPostDTO, BlogPost>().ReverseMap();
        CreateMap<CreateBlogPostCommand, BlogPost>().ReverseMap();
    }
}
