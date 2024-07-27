using Domain.Base;

namespace Domain
{
    public class Category: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Category? ParentCategory { get; set; }
        public string? ParentCategoryId { get; set; }
        public Section? Section { get; set; }
        public string? SectionId { get; set; }

        public int HeadingCounter { get; set; }
        public int PostCounter { get; set; }

        public string? LastHeadingId { get; set; }
        public string? LastPostId { get; set; }
        public string? LastUserName { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
