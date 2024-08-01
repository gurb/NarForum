namespace BlazorUI.Models.BlogPost;

public class GetBlogPostsWithPaginationQueryVM
{
    public Guid BlogCategoryId { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}
