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

        /// <summary>
        /// Gets logo.
        /// </summary>
        /// <returns>The getting logo result as ForumSettingsDTO</returns>
        [HttpPost("GetForumSettings")]
        public async Task<ForumSettingsDTO> GetLogo()
        {
            var response = await _mediator.Send(new GetForumSettingsQuery());
            return response;
        }

        /// <summary>
        /// Updates forum settings.
        /// </summary>
        /// <param name="command">The command containing ForumUrl, IsShowCookieConsent fields.</param>
        /// <returns>The updating forum settings result as ApiResponse.</returns>
        [HttpPost("UpdateForumSettings")]
        public async Task<ApiResponse> UpdateForumSettings(UpdateForumSettingsCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
