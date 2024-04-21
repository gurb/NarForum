using Domain.Base;

namespace Domain
{
    public class Post: BaseEntity
    {
        public Heading? Heading { get; set; }
        public int? HeadingId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
