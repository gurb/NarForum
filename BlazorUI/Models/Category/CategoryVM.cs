namespace BlazorUI.Models.Category
{
    public class CategoryVM
    {
        public string? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? SectionId { get; set; }
        public string? ParentCategoryId { get; set; }
        public int HeadingCounter { get; set; }
        public int PostCounter { get; set; }


        public string? LastHeadingId { get; set; }
        public string? LastPostId { get; set; }
        public string? LastHeadingTitle { get; set; }
        public string? LastUserName { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
