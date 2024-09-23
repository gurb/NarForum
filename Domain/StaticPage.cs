using Domain.Base;


namespace Domain;

public class StaticPage: BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Guid? UserId { get; set; }
    public bool IsDraft { get; set; }
    public bool IsPublished { get; set; }
}

