using Domain.Base;

namespace Domain
{
    public class Heading: BaseEntity
    {
        public string? Title { get; set; }
        public Category? Category { get; set; }
        public string? CategoryId { get; set; }
        public string? UserName { get; set; }
        public string? MainPostId { get; set; }
        public bool IsLock { get; set; }

        public int PostCounter { get; set; }

        public string? LastUserName { get; set; }
        public string? LastPostId { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
