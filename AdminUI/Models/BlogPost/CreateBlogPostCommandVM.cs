namespace AdminUI.Models.BlogPost;

public class CreateBlogPostCommandVM
{
    public int? BlogCategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Url { get; set; } = string.Empty;
}
