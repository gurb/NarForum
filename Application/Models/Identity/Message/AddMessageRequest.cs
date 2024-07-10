namespace Application.Models.Identity.Message
{
    public class AddMessageRequest
    {
        public string? OwnerId { get; set; }
        public string? ReceiverId { get; set; }
        public string? Text { get; set; }
    }
}
