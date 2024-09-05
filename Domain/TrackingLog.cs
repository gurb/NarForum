using Domain.Models.Enums;

namespace Domain
{
    public class TrackingLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Country { get; set; }
        public string? IpAddress { get; set; }
        public DateTime DateTime { get; set; }
        public string? URL { get; set; }
        public bool IsMember { get; set; }
        public TrackingType Type { get; set; }
        public Guid? TargetId { get; set; }
        public Guid? TempUserId { get; set; }
    }
}
