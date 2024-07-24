using BlazorUI.Models.Enums;
using BlazorUI.Models.User;

namespace BlazorUI.Models.Message
{
    public class ChatVM
    {
        public string? Id { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public string? CreatorId { get; set; }
        public UserVM? Creator { get; set; }
        public string? ReceiverId { get; set; }
        public UserVM? Receiver { get; set; }
        public ChatStatusVM Status { get; set; } = ChatStatusVM.Pending;
        public DateTime DateTime { get; set; }
    }
}
