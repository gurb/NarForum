namespace BlazorUI.Models.Like
{
    public class LikeVM
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public Guid? UserId { get; set; }
        public Guid HeadingId { get; set; }
        public Guid PostId { get; set; }
        public DateTime DateTime { get; set; }
        public bool? IsLike { get; set; }
    }
}
