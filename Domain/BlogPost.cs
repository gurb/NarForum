using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class BlogPost: BaseEntity
{
    public int BlogPostId { get; set; }
    public BlogCategory? BlogCategory { get; set; }
    public Guid? BlogCategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public int ViewCounter { get; set; }
    public bool IsDraft { get; set; }
    public bool IsPublished { get; set; }
}
