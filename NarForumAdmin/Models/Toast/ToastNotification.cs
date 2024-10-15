using NarForumAdmin.Models.Enums;

namespace NarForumAdmin.Models.Toast
{
    public class ToastNotification
    {
        public ToastTypeVM Type { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? RightText { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public string? Message { get; set; }
        public bool CanHide { get; set; }
        public bool IsShow { get; set; }
    }
}
