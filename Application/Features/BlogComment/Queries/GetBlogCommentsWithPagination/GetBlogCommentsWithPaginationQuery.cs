
using MediatR;

namespace Application.Features.BlogComment.Queries.GetBlogCommentsWithPagination;

public class GetBlogCommentsWithPaginationQuery: IRequest<BlogCommentsPaginationDTO>
{
    public int? BlogPostId { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}
