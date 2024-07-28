using Domain.Base;

namespace Domain;

public class BlogPost: BaseEntity
{
    public BlogCategory? BlogCategory { get; set; }
    public Guid BlogCategoryId { get; set; } = Guid.Empty;
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public int ViewCounter { get; set; }
    public bool IsDraft { get; set; }
    public bool IsPublished { get; set; }
}
