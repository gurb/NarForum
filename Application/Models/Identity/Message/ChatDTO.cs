using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Identity.Message
{
    public class ChatDTO
    {
        public string? Subject { get; set; }
        public string? Text { get; set; }
        public string? OwnerId { get; set; }
        public UserDTO? Owner { get; set; }
        public string? ReceiverId { get; set; }
        public UserDTO? Receiver { get; set; }
    }
}
