using Application.Features.TrackingLog.Commands.AddTrackingLog;
using Application.Features.TrackingLog.Queries.GetTrackingLog;
using Application.Features.TrackingLog.Queries.GetTrackingLogs;
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
        public async Task<List<TrackingLogDTO>> GetBlogCategories(GetTrackingLogsQuery query)
        {
            var trackingLogs = await _mediator.Send(query);

            return trackingLogs;
        }


        [HttpPost("GetTrackingLog")]
        public async Task<TrackingLogDTO> GetBlogCategory(GetTrackingLogQuery query)
        {
            var trackingLog = await _mediator.Send(query);

            return trackingLog;
        }

        [AllowAnonymous]
        [HttpPost("AddTrackingLog")]

        public async Task<ApiResponse> AddBlogCategory(AddTrackingLogCommand command)
        {

            this.HttpContext.Connection.RemoteIpAddress.ToString();

            var response = await _mediator.Send(command);
            return response;
        }
        
    }
}
