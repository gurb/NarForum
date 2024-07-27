using MediatR;

namespace Application.Features.BlogComment.Queries.GetBlogComments;

public class GetBlogCommentsQuery: IRequest<List<BlogCommentDTO>>
{
    public string? BlogPostId { get; set; }
}
