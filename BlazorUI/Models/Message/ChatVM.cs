using BlazorUI.Models.User;

namespace BlazorUI.Models.Message
{
    public class ChatVM
    {
        public string? Subject { get; set; }
        public string? Text { get; set; }
        public string? OwnerId { get; set; }
        public UserVM? Owner { get; set; }
        public string? ReceiverId { get; set; }
        public UserVM? Receiver { get; set; }
    }
}
