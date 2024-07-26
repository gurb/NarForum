using AdminUI.Models.BlogCategory;

namespace AdminUI.Models.BlogPost;

public class BlogPostVM
{
    public int? Id { get; set; }
    public BlogCategoryVM? BlogCategory { get; set; }
    public int? BlogCategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public int ViewCounter { get; set; }
}
