using NarForumAdmin.Models.BlogCategory;

namespace NarForumAdmin.Models.BlogPost;

public class BlogPostVM
{
    public Guid? Id { get; set; }
    public BlogCategoryVM? BlogCategory { get; set; }
    public Guid? BlogCategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string DisplayContent { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public Guid? UserId { get; set; }
    public int ViewCounter { get; set; }
    public bool IsDraft { get; set; }
    public bool IsPublished { get; set; }
}
