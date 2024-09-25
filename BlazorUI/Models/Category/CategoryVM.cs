namespace BlazorUI.Models.Category
{
    public class CategoryVM
    {
        public Guid Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
		public Guid? SectionId { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public int HeadingCounter { get; set; }
        public int PostCounter { get; set; }


        public string? LastCategoryTitle { get; set; }
        public int? LastCategoryId { get; set; }
        public Guid? LastHeadingId { get; set; }
        public Guid? LastPostId { get; set; }
        public string? LastHeadingTitle { get; set; }
        public string? LastUserName { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
