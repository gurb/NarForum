﻿namespace Application.Models.Identity.Message;

public class CreateChatRequest
{
    public string? OwnerId { get; set; }
    public string? ReceiverId { get; set; }
    public string? Subject { get; set; }
    public string? Text { get; set; }
}
