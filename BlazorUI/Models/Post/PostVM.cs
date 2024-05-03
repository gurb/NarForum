namespace BlazorUI.Models.Post
{
    public class PostVM
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int HeadingId { get; set; }
        public string UserName { get; set; } = string.Empty;

        public string? CategoryName { get; set; }
        public string? HeadingTitle { get; set; }
        public int? HeadingIndex { get; set; }
        public int? PageIndex { get; set; }
    }
}
