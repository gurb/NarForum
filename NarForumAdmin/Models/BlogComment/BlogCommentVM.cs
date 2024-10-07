using NarForumAdmin.Models.BlogPost;

namespace NarForumAdmin.Models.BlogComment;

public class BlogCommentVM
{
    public Guid Id { get; set; }
    public BlogPostVM? BlogPost { get; set; }
    public Guid BlogPostId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public Guid? UserId { get; set; }
}
