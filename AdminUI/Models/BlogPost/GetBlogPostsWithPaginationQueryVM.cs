namespace AdminUI.Models.BlogPost;

public class GetBlogPostsWithPaginationQueryVM
{
    public string? Title { get; set; }
    public bool IsInclude { get; set; } = false;
    public Guid? BlogCategoryId { get; set; }
    public string? SearchTitle { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}
