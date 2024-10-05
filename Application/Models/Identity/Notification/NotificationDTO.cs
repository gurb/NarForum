using Application.Features.Category.Queries.GetCategories;
using Application.Features.Heading.Queries;
using Application.Models.Enums;
using Application.Models.Identity.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Identity.Notification
{
    public class NotificationDTO
    {
        public string? Id { get; set; }
        public bool IsRead { get; set; }
        public string? Message { get; set; }
        public string? CreatorId { get; set; }
        public UserDTO? Creator { get; set; }
        public string? ReceiverId { get; set; }
        public UserDTO? Receiver { get; set; }
        public NotificationType Type { get; set; }
        public DateTime DateTime { get; set; }
        public HeadingDTO? Heading { get; set; }
        public CategoryDTO? Category { get; set; }
        public int? HeadingIndex { get; set; }
    }
}
