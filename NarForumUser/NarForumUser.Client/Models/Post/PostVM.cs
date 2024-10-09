using NarForumUser.Client.Models.User;

namespace NarForumUser.Client.Models.Post
{
    public class PostVM
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid HeadingId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public Guid? UserId { get; set; }

        public string? CategoryName { get; set; }
        public int? CategoryIntId { get; set; }
        public string? HeadingTitle { get; set; }
        public int? HeadingIndex { get; set; }
        public int? PageIndex { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreate { get; set; }


        // not in database
        public bool? IsLike { get; set; }
        public int LikeCounter { get; set; }
        public int UnlikeCounter { get; set; }
        public int PostCounter { get; set; }
        public bool IsFavorite { get; set; }
        public string DisplayContent { get; set; } = string.Empty;
        public List<Guid> QuotePostIds { get; set; } = new List<Guid>();
        public string? UserProfileImageUrl { get; set; }
        public UserInfoVM? UserInfoVM { get; set; }

    }
}
