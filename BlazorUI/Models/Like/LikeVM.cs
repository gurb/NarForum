namespace BlazorUI.Models.Like
{
    public class LikeVM
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? HeadingId { get; set; }
        public string? PostId { get; set; }
        public DateTime DateTime { get; set; }
        public bool? IsLike { get; set; }
    }
}
