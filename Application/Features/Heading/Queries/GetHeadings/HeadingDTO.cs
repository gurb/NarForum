namespace Application.Features.Heading.Queries
{
    public class HeadingDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? CategoryId { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public int MainPostId { get; set; }
    }
}
