namespace BlazorUI.Models.BlogPost;

public class UpdateBlogPostCommandVM
{
    public string? Id { get; set; }
    public string? BlogCategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
