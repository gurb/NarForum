namespace BlazorUI.Models.Post
{
    public class PostsPaginationVM
    {
        public List<PostVM>? Posts { get; set; }
        public List<PostVM>? QuotePosts { get; set; }
        public int TotalCount { get; set; }
    }
}
