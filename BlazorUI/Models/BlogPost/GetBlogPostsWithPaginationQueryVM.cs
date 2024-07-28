namespace BlazorUI.Models.BlogPost;

public class GetBlogPostsWithPaginationQueryVM
{
    public string? BlogCategoryId { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}
