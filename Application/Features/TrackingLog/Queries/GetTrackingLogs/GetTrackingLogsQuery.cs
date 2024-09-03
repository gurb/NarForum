using Application.Features.TrackingLog.Queries.GetTrackingLog;
using MediatR;

namespace Application.Features.TrackingLog.Queries.GetTrackingLogs
{

    public class GetTrackingLogsQuery : IRequest<List<TrackingLogDTO>>
    {
        public string? SearchText { get; set; }
    }
}
