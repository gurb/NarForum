namespace BlazorUI.Models.BlogPost;

public class UpdateBlogPostCommandVM
{
    public int Id { get; set; }
    public int? BlogCategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
