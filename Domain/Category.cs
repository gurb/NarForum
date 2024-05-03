using Domain.Base;

namespace Domain
{
    public class Category: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public Category? ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }
        public Section? Section { get; set; }
        public int? SectionId { get; set; }

        public int HeadingCounter { get; set; }
    }
}
