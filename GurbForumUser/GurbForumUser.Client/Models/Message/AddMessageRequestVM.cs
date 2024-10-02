namespace GurbForumUser.Client.Models.Message
{
    public class AddMessageRequestVM
    {
        public string? ChatId { get; set; }
        public string? OwnerId { get; set; }
        public string? Text { get; set; }
    }
}
