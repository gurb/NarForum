namespace BlazorUI.Models.Message
{
    public class CreateChatRequestVM
    {
        public string? OwnerId { get; set; }
        public string? ReceiverId { get; set; }
        public string? Subject { get; set; }
        public string? Text { get; set; }
    }
}
