using Application.Models.Enums;

namespace Application.Features.TrackingLog.Queries.GetTrackingLog
{
    public class TrackingLogDTO
    {
        public Guid Id { get; set; }
        public string? Country { get; set; }
        public string? IpAddress { get; set; }
        public DateTime DateTime { get; set; }
        public string? URL { get; set; }
        public bool IsMember { get; set; }
        public TrackingType Type { get; set; }
        public Guid? TargetId { get; set; }
        public Guid? TempUserId { get; set; }
        public string? Browser { get; set; }
    }
}
