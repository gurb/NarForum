using BlazorUI.Models.Enums;

namespace BlazorUI.Models.Message
{
    public class ChangeChatStatusRequestVM
    {
        public string? ChatId { get; set; }
        public ChatStatusVM Status { get; set; }
    }
}
