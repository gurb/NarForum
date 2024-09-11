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


        [HttpPost("GetTrackingLogs")]
        public async Task<List<TrackingLogDTO>> GetTrackingLogs(GetTrackingLogsQuery query)
        {
            var trackingLogs = await _mediator.Send(query);

            return trackingLogs;
        }


        [HttpPost("GetTrackingLog")]
        public async Task<TrackingLogDTO> GetTrackingLog(GetTrackingLogQuery query)
        {
            var trackingLog = await _mediator.Send(query);

            return trackingLog;
        }

		[HttpPost("GetTrackingLogsWithPagination")]
		public async Task<TrackingLogsPaginationDTO> GetTrackingLogsWithPagination(GetTrackingLogsWithPaginationQuery request)
		{
			var dto = await _mediator.Send(request);

			return dto;
		}

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
