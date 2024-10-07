namespace NarForumUser.Client.Models.StaticPage
{
    public class CreateStaticPageCommandVM
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }
}
