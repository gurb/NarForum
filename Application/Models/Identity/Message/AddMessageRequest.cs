namespace Application.Models.Identity.Message
{
    public class AddMessageRequest
    {
        public string? ChatId { get; set; }
        public string? OwnerId { get; set; }
        public string? Text { get; set; }
    }
}
