using MediatR;


namespace Application.Features.BlogPost.Queries.GetBlogPostsWithPagination;

public class GetBlogPostsWithPaginationQuery: IRequest<BlogPostsPaginationDTO>
{
    public Guid? BlogCategoryId { get; set; }
    public bool IsInclude { get; set; } = false;
    public string? SearchTitle { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}
