namespace Application.Features.Heading.Queries
{
    public class HeadingDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Content { get; set; }
        public string? UserName { get; set; } = string.Empty;
        public int MainPostId { get; set; }

        public int PostCounter { get; set; }
    }
}
