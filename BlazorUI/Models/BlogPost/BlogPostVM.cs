using BlazorUI.Models.BlogCategory;

namespace BlazorUI.Models.BlogPost;

public class BlogPostVM
{
    public BlogCategoryVM? BlogCategory { get; set; }
    public string? BlogCategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string DisplayContent { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public int ViewCounter { get; set; }

    public DateTime? DateCreate { get; set; }
}
