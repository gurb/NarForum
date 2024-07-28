namespace AdminUI.Models.Category
{
    public class CategoryVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid SectionId { get; set; }
        public Guid ParentCategoryId { get; set; }
        public int HeadingCounter { get; set; }
        public int PostCounter { get; set; }


        public Guid LastHeadingId { get; set; }
        public Guid LastPostId { get; set; }
        public string? LastHeadingTitle { get; set; }
        public string? LastUserName { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
