namespace BlazorUI.Models.Post
{
    public class PostVM
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int HeadingId { get; set; }
        public int UserId { get; set; }
    }
}
