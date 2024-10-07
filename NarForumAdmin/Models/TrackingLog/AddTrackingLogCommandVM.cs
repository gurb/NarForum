using NarForumAdmin.Models.Enums;

namespace NarForumAdmin.Models.TrackingLog
{
    public class AddTrackingLogCommandVM
    {
        public string? Country { get; set; }
        public string? IpAddress { get; set; }
        public DateTime DateTime { get; set; }
        public string? URL { get; set; }
        public bool IsMember { get; set; }
        public TrackingTypeVM Type { get; set; }
        public Guid? TargetId { get; set; }
        public Guid? TempUserId { get; set; }
    }
}
