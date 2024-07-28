namespace BlazorUI.Models.Heading
{
    public class HeadingVM
    {
        public string? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Content { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? MainPostId { get; set; }

        public int PostCounter { get; set; }


        public string? LastPostId { get; set; }
        public string? LastUserName { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
