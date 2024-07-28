namespace BlazorUI.Models.BlogComment;

public class CreateBlogCommentCommandVM
{
    public string? BlogPostId { get; set; }
    public string Content { get; set; } = string.Empty;
}
