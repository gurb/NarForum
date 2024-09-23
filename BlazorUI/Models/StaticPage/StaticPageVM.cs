namespace BlazorUI.Models.StaticPage
{
    public class StaticPageVM
    {
        public string? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public Guid? UserId { get; set; }
    }
}
