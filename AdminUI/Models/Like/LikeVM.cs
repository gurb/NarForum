namespace AdminUI.Models.Like
{
    public class LikeVM
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int? HeadingId { get; set; }
        public int? PostId { get; set; }
        public DateTime DateTime { get; set; }
        public bool? IsLike { get; set; }
    }
}
