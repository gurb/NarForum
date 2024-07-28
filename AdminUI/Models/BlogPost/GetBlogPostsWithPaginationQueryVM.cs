namespace AdminUI.Models.BlogPost;

public class GetBlogPostsWithPaginationQueryVM
{
    public string? Title { get; set; }
    public Guid? BlogCategoryId { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}
