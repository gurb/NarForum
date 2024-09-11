using Application.Features.TrackingLog.Queries.GetTrackingLog;

namespace Application.Features.TrackingLog.Queries.GetTrackingLogsWithPagination
{
	public class TrackingLogsPaginationDTO
	{
		public List<TrackingLogDTO>? TrackingLogs { get; set; }
		public int TotalCount { get; set; }
		public Dictionary<Guid, int>? ViewCounters { get; set; }
	}
}
