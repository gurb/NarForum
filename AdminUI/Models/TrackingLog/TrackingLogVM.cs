using AdminUI.Models.Enums;
using AdminUI.Models.Heading;

namespace AdminUI.Models.TrackingLog
{
    public class TrackingLogVM
    {
		public Guid Id { get; set; }
		public string? Country { get; set; }
		public string? IpAddress { get; set; }
		public DateTime DateTime { get; set; }
		public string? URL { get; set; }
		public bool IsMember { get; set; }
		public TrackingTypeVM Type { get; set; }
		public Guid? TargetId { get; set; }
		public Guid? TempUserId { get; set; }
		public string? Browser { get; set; }
		public HeadingVM? Heading { get; set; }
		public int ViewCounter { get; set; }
	}
}
