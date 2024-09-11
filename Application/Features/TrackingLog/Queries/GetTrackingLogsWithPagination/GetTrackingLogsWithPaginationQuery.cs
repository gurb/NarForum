using Application.Features.TrackingLog.Queries.GetTrackingLog;
using Application.Models.Enums;
using MediatR;


namespace Application.Features.TrackingLog.Queries.GetTrackingLogsWithPagination
{
	public class GetTrackingLogsWithPaginationQuery : IRequest<TrackingLogsPaginationDTO>
	{
		public TrackingType? TrackingType { get; set; }
		public TrackingLogDateType DateType { get; set; } = TrackingLogDateType.DAY;
		public DateTime DateTime { get; set; } = DateTime.UtcNow;
		public string? TimeZone { get; set; }
		public bool IncludeTarget { get; set; }

		public int? PageIndex { get; set; }
		public int? PageSize { get; set; }


	}
}
