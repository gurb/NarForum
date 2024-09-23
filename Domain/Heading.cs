using Domain.Base;

namespace Domain
{
    public class Heading: BaseEntity
    {
        public string? Title { get; set; }
        public Category? Category { get; set; }
        public Guid CategoryId { get; set; }
        public string? UserName { get; set; }
        public Guid? UserId { get; set; }
        public Guid MainPostId { get; set; }
        public bool IsLock { get; set; }

        public int PostCounter { get; set; }

        public string? LastUserName { get; set; }
        public Guid LastPostId { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
