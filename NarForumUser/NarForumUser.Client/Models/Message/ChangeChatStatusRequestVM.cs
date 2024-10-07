using NarForumUser.Client.Models.Enums;

namespace NarForumUser.Client.Models.Message
{
    public class ChangeChatStatusRequestVM
    {
        public string? ChatId { get; set; }
        public ChatStatusVM Status { get; set; }
    }
}
