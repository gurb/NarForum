using Application.Features.BlogComment.Commands.CreateBlogComment;
using Application.Features.BlogComment.Queries.GetBlogComments;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class BlogCommentProfile: Profile
    {
        public BlogCommentProfile()
        {
            CreateMap<BlogCommentDTO, BlogComment>().ReverseMap();
            CreateMap<CreateBlogCommentCommand, BlogComment>().ReverseMap();
        }
    }
}
