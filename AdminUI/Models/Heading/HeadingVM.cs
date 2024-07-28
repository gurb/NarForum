namespace AdminUI.Models.Heading
{
    public class HeadingVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Content { get; set; }
        public string UserName { get; set; } = string.Empty;
        public Guid MainPostId { get; set; }

        public int PostCounter { get; set; }


        public Guid LastPostId { get; set; }
        public string? LastUserName { get; set; }
        public DateTime? ActiveDate { get; set; }
    }
}
