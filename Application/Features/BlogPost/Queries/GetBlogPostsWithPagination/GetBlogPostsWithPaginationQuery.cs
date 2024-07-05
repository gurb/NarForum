using MediatR;


namespace Application.Features.BlogPost.Queries.GetBlogPostsWithPagination;

public class GetBlogPostsWithPaginationQuery: IRequest<BlogPostsPaginationDTO>
{
    public int? BlogCategoryId { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}
