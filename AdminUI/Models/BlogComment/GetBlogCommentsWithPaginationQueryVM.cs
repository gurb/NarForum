namespace AdminUI.Models.BlogComment;

public class GetBlogCommentsWithPaginationQueryVM
{
    public string? Content { get; set; }
    public int? BlogPostId { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}
