using NarForumAdmin.Models.Enums;

namespace NarForumAdmin.Models.TrackingLog
{
    public class GetTrackingLogsQueryVM
    {
		public TrackingTypeVM TrackingType { get; set; }
		public TrackingLogDateType DateType { get; set; } = TrackingLogDateType.DAY;
		public DateTime DateTime { get; set; } = DateTime.UtcNow;
		public string? TimeZone { get; set; }
		public bool IncludeTarget { get; set; }
	}
}
