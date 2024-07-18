using Identity.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class Chat
    {
        [Key]
        public string? Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("CreatorId")]
        public ForumUser? Creator { get; set; }
        public string? CreatorId { get; set; }

        public string? Subject { get; set; }
        public string? Message { get; set; }

        public DateTime DateTime { get; set; }
        public ChatStatus Status { get; set; } = ChatStatus.Pending;

        [ForeignKey("ReceiverId")]
        public ForumUser? Receiver { get; set; }
        public string? ReceiverId { get; set; }

        public bool IsVisibleForCreator { get; set; } = true;
        public bool IsVisibleForReceiver { get; set; } = true;
    }
}
