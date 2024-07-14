namespace Application.Models.Identity.Message;

public class GetChatResponse
{
    public List<ChatDTO> Chats { get; set; } = new List<ChatDTO>();
}
