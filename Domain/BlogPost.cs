using Domain.Base;

namespace Domain;

public class BlogPost: BaseEntity
{
    public BlogCategory? BlogCategory { get; set; }
    public int? BlogCategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public int ViewCounter { get; set; }
    public bool IsDraft { get; set; }
    public bool IsPublished { get; set; }
}
