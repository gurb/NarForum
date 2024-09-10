using Application.Features.TrackingLog.Queries.GetTrackingLog;
using Application.Models.Enums;
using MediatR;

namespace Application.Features.TrackingLog.Queries.GetTrackingLogs
{

    public class GetTrackingLogsQuery : IRequest<List<TrackingLogDTO>>
    {
		public TrackingType? TrackingType { get; set; }
		public TrackingLogDateType DateType { get; set; } = TrackingLogDateType.DAY;
		public DateTime DateTime { get; set; } = DateTime.UtcNow;
		public string? TimeZone { get; set; }
	}
}
