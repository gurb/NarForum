using Domain.Base;

namespace Domain;

public class BlogComment: BaseEntity
{
    public BlogPost? BlogPost { get; set; }
    public Guid BlogPostId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}
