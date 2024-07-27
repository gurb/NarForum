using AdminUI.Models.BlogPost;

namespace AdminUI.Models.BlogComment;

public class BlogCommentVM
{
    public int? Id { get; set; }
    public BlogPostVM? BlogPost { get; set; }
    public int? BlogPostId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}
