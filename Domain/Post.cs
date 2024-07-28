using Domain.Base;

namespace Domain
{
    public class Post: BaseEntity
    {
        public Heading? Heading { get; set; }
        public Guid HeadingId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public int HeadingIndex { get; set; }
    }
}
