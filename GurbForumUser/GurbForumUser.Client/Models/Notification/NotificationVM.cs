using GurbForumUser.Client.Models.Category;
using GurbForumUser.Client.Models.Enums;
using GurbForumUser.Client.Models.Heading;
using GurbForumUser.Client.Models.User;

namespace GurbForumUser.Client.Models.Notification
{
    public class NotificationVM
    {
        public string? Id { get; set; }
        public bool IsRead { get; set; }
        public string? Message { get; set; }
        public string? CreatorId { get; set; }
        public UserInfoVM? Creator { get; set; }
        public string? ReceiverId { get; set; }
        public UserInfoVM? Receiver { get; set; }
        public NotificationTypeVM Type { get; set; }
        public DateTime DateTime { get; set; }
        public HeadingVM? Heading { get; set; }
        public CategoryVM? Category { get; set; }
        public int? HeadingIndex { get; set; }
    }
}
