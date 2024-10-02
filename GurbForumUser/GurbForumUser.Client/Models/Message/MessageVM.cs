namespace GurbForumUser.Client.Models.Message
{
    public class MessageVM
    {
        public string? Id { get; set; }
        public string? ChatId { get; set; }
        public UserVM? Owner { get; set; }
        public string? OwnerId { get; set; }
        public string? Text { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsRead { get; set; }
    }
}
