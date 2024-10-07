namespace NarForumAdmin.Models.StaticPage
{
    public class StaticPageVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
		public string DisplayContent { get; set; } = string.Empty;
		public string Url { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public bool IsDraft { get; set; }
        public bool IsPublished { get; set; }
    }
}
