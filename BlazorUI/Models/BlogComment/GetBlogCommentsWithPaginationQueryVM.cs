namespace BlazorUI.Models.BlogComment;

public class GetBlogCommentsWithPaginationQueryVM
{
    public string? BlogPostId { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}
