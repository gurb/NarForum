namespace GurbForumUser.Client.Models.BlogComment;

public class UpdateBlogCommentCommandVM
{
    public string? Id { get; set; }
    public string Content { get; set; } = string.Empty;
}
