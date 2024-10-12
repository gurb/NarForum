using NarForumUser.Client.Models.Enums;

namespace NarForumUser.Client.Models.Toast
{
    public class ToastNotification
    {
        public ToastTypeVM Type { get; set; } 
        public string? Title { get; set; }
        public string? RightText { get; set; }
        public string? Message { get; set; }
        public bool CanHide { get; set; }
        public bool IsShow { get; set; }
    }
}
