using Domain.Base;

namespace Domain
{
    public class Heading: BaseEntity
    {
        public string? Title { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public string? UserName { get; set; }
        public int? MainPostId { get; set; }
    }
}
