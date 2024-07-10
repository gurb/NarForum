using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class Message
    {
        [Key]
        public string? Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("OwnerId")]
        public ForumUser? Owner { get; set; }
        public string? OwnerId { get; set; }

        [ForeignKey("ReceiverId")]
        public ForumUser? Receiver { get; set; }
        public string? ReceiverId { get; set; }

        public string? Text { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsRead { get; set; }

        public bool IsVisibleForOwner { get; set; } = true;
        public bool IsVisibleForReceiver { get; set; } = true;
    }
}
