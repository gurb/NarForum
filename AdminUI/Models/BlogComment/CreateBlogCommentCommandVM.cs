namespace AdminUI.Models.BlogComment;

public class CreateBlogCommentCommandVM
{
    public int? BlogPostId { get; set; }
    public string Content { get; set; } = string.Empty;
}
