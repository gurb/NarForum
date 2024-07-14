using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models;

public class Message
{
    [Key]
    public string? Id { get; set; } = Guid.NewGuid().ToString();

    [ForeignKey("ChatId")]
    public Chat? Chat { get; set; }
    public string? ChatId { get; set; }

    [ForeignKey("OwnerId")]
    public ForumUser? Owner { get; set; }
    public string? OwnerId { get; set; }

    public string? Text { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsRead { get; set; }

    public bool IsVisibleForOwner { get; set; } = true;
    public bool IsVisibleForReceiver { get; set; } = true;
}
