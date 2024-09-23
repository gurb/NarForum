namespace BlazorUI.Models.BlogComment;

public class CreateBlogCommentCommandVM
{
    public Guid? BlogPostId { get; set; }
    public string Content { get; set; } = string.Empty;
}
