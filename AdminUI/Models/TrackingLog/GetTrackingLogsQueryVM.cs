using AdminUI.Models.Enums;

namespace AdminUI.Models.TrackingLog
{
    public class GetTrackingLogsQueryVM
    {
		public TrackingTypeVM TrackingType { get; set; } = null;
		public TrackingLogDateType DateType { get; set; } = TrackingLogDateType.DAY;
		public DateTime DateTime { get; set; } = DateTime.UtcNow;
		public string? TimeZone { get; set; }
	}
}
