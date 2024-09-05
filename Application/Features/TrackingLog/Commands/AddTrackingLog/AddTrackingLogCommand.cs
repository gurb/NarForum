using Application.Models;
using Application.Models.Enums;
using MediatR;

namespace Application.Features.TrackingLog.Commands.AddTrackingLog
{
    public class AddTrackingLogCommand : IRequest<ApiResponse>
    {
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
