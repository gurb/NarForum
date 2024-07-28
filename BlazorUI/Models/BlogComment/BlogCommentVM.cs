using BlazorUI.Models.BlogPost;

namespace BlazorUI.Models.BlogComment;

public class BlogCommentVM
{
    public BlogPostVM? BlogPost { get; set; }
    public string? BlogPostId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}
