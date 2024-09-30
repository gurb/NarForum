namespace BlazorUI.Models.Heading
{
    public class HeadingVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Content { get; set; }
        public string UserName { get; set; } = string.Empty;
        public Guid? UserId { get; set; }
        public Guid MainPostId { get; set; }
        public bool IsLock { get; set; }
        public bool IsPin { get; set; }

        public int PostCounter { get; set; }

        public int CategoryIntId { get; set; }
        public Guid? LastPostId { get; set; }
        public string? LastUserName { get; set; }
        public Guid? LastUserId { get; set; }
        public DateTime? ActiveDate { get; set; }
        public string? UserProfileImageUrl { get; set; }
    }
}
