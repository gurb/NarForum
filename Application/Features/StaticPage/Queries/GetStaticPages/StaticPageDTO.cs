namespace Application.Features.StaticPage.Queries.GetStaticPages
{
    public class StaticPageDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }
}
