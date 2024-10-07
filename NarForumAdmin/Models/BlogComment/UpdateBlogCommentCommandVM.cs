namespace NarForumAdmin.Models.BlogComment;

public class UpdateBlogCommentCommandVM
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
}
