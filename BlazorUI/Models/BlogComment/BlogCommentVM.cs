using BlazorUI.Models.BlogPost;

namespace BlazorUI.Models.BlogComment;

public class BlogCommentVM
{
    public BlogPostVM? BlogPost { get; set; }
    public Guid? BlogPostId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public Guid? UserId { get; set; }

    public string? UserProfileImageUrl { get; set; }

}
