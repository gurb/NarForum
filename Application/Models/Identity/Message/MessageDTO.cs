namespace Application.Models.Identity.Message
{
    public class MessageDTO
    {
        public string? Id { get; set; }
        public string? ChatId { get; set; }
        public string? OwnerId { get; set; }
        public UserDTO? Owner { get; set; }
        public string? Text { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsRead { get; set; }
    }
}
