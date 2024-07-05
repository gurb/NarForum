using MediatR;

namespace Application.Features.BlogComment.Queries.GetBlogComments;

public class GetBlogCommentsQuery: IRequest<List<BlogCommentDTO>>
{
    public int? BlogPostId { get; set; }
}
