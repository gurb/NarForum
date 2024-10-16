using Application.Features.TrackingLog.Commands.AddTrackingLog;
using Application.Features.TrackingLog.Queries.GetTrackingLog;
using Application.Features.TrackingLog.Queries.GetTrackingLogs;
using Application.Features.TrackingLog.Queries.GetTrackingLogsWithPagination;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingLogController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrackingLogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets tracking logs.
        /// </summary>
        /// <param name="query">The request containing TrackingType(TrackingLogType as enum), DateType(TrackingLogDateType as enum), DateTime(DateTime), 
        /// TimeZone(string), IncludeTarget(bool) fields.</param>
        /// <returns>The getting tracking logs result as the list of TrackingLogDTO.</returns>
        [HttpPost("GetTrackingLogs")]
        public async Task<List<TrackingLogDTO>> GetTrackingLogs(GetTrackingLogsQuery query)
        {
            var trackingLogs = await _mediator.Send(query);

            return trackingLogs;
        }

        /// <summary>
        /// Gets tracking log.
        /// </summary>
        /// <param name="query">The request containing Id(Guid) field.</param>
        /// <returns>The getting tracking log result as TrackingLogDTO.</returns>
        [HttpPost("GetTrackingLog")]
        public async Task<TrackingLogDTO> GetTrackingLog(GetTrackingLogQuery query)
        {
            var trackingLog = await _mediator.Send(query);

            return trackingLog;
        }

        /// <summary>
        /// Gets tracking logs with server-side pagination.
        /// </summary>
        /// <param name="request">The request containing TrackingType(TrackingLogType as enum), DateType(TrackingLogDateType as enum), DateTime(DateTime), 
        /// TimeZone(string), IncludeTarget(bool), PageIndex(int) and PageSize(int) fields. </param>
        /// <returns>The getting the part of the list of track and total size of the posts as PostsPaginationDTO.</returns>
		[HttpPost("GetTrackingLogsWithPagination")]
		public async Task<TrackingLogsPaginationDTO> GetTrackingLogsWithPagination(GetTrackingLogsWithPaginationQuery request)
		{
			var dto = await _mediator.Send(request);

			return dto;
		}

        /// <summary>
        /// Adds tracking log.
        /// </summary>
        /// <param name="command">The request containing Country(string), IpAddress(string), DateTime(DateTime), URL(string), IsMember(bool),
        /// Type(TrackingType), TargetId(Guid), TempUserId(Guid), Browser(string) fields.</param>
        /// <returns>The adding tracking log result as ApiResponse</returns>
		[AllowAnonymous]
        [HttpPost("AddTrackingLog")]
        public async Task<ApiResponse> AddTrackingLog(AddTrackingLogCommand command)
        {
            string ipAddress = this.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            if (ipAddress != null && ipAddress != "::1")
            {
                command.IpAddress = ipAddress;
            }

            var response = await _mediator.Send(command);
            return response;
        }
        
    }
}
