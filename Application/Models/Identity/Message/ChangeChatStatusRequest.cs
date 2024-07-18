using Application.Models.Enums;

namespace Application.Models.Identity.Message;

public class ChangeChatStatusRequest
{
    public string? ChatId { get; set; }
    public ChatStatus Status { get; set; }
}
