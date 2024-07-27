using Application.Features.BlogPost.Queries.GetBlogPosts;
using MediatR;

namespace Application.Features.BlogPost.Queries.GetBlogPost;

public class GetBlogPostQuery: IRequest<BlogPostDTO>
{
    public string? Id { get; set; }
}
