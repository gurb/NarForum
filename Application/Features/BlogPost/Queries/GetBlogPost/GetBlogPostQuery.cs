using Application.Features.BlogPost.Queries.GetBlogPosts;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetBlogPost;

public class GetBlogPostQuery: IRequest<BlogPostDTO>
{
    public int? IntId { get; set; }
    public Guid? Id { get; set; }
}
