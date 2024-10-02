using GurbForumUser.Client.Models.Enums;

namespace GurbForumUser.Client.Models.Message
{
    public class ChangeChatStatusRequestVM
    {
        public string? ChatId { get; set; }
        public ChatStatusVM Status { get; set; }
    }
}
