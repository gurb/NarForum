namespace BlazorUI.Models.Heading
{
    public class HeadingVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public int MainPostId { get; set; }
    }
}
