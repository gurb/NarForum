using MediatR;

namespace Application.Features.BlogComment.Queries.GetBlogComments;

public class GetBlogCommentsQuery: IRequest<List<BlogCommentDTO>>
{
    public Guid BlogPostId { get; set; }
}
