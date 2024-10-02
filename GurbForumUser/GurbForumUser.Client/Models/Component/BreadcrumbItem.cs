namespace GurbForumUser.Client.Models.Component
{
    public class BreadcrumbItem
    {
        public string? Text { get; set; }
        public string? HrefLink { get; set; }
        public bool IsCurrentPage { get; set; }
    }
}
