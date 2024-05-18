namespace AdminUI.Models.Post
{
    public class PostVM
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int HeadingId { get; set; }
        public string UserName { get; set; } = string.Empty;

        public string? CategoryName { get; set; }
        public string? HeadingTitle { get; set; }
        public int? HeadingIndex { get; set; }
        public int? PageIndex { get; set; }


        // not in database
        public bool? IsLike { get; set; }
        public int LikeCounter { get; set; }
        public int UnlikeCounter { get; set; }
        public bool IsFavorite { get; set; }
        public string DisplayContent { get; set; } = string.Empty;
        public List<int?> QuotePostIds { get; set; } = new List<int?>();
    }
}
