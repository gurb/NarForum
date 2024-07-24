using Application.Models.Enums;

namespace Application.Models.Identity.Message
{
    public class ChatDTO
    {
        public string? Id { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public string? CreatorId { get; set; }
        public UserDTO? Creator { get; set; }
        public string? ReceiverId { get; set; }
        public UserDTO? Receiver { get; set; }
        public ChatStatus Status { get; set; }
        public DateTime DateTime { get; set; }
    }
}
