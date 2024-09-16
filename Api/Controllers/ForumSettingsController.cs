using Application.Features.ForumSetting.Commands.UpdateForumSettings;
using Application.Features.ForumSetting.Queries.GetForumSettings;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumSettingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ForumSettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetForumSettings")]
        public async Task<ForumSettingsDTO> GetLogo()
        {
            var response = await _mediator.Send(new GetForumSettingsQuery());
            return response;
        }


        [HttpPost("UpdateForumSettings")]
        public async Task<ApiResponse> UpdateForumSettings(UpdateForumSettingsCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
