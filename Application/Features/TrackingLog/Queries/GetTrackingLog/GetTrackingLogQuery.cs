using MediatR;

namespace Application.Features.TrackingLog.Queries.GetTrackingLog
{
    public class GetTrackingLogQuery : IRequest<TrackingLogDTO>
    {
        public Guid? Id { get; set; }
    }
}
