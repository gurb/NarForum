namespace BlazorUI.Models.BlogPost;

public class GetBlogPostsWithPaginationQueryVM
{
    public bool IsInclude { get; set; } = false;
    public Guid? BlogCategoryId { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}
