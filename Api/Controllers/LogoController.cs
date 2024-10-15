using Application.Features.Logo.Commands.AddLogo;
using Application.Features.Logo.Commands.RemoveLogo;
using Application.Features.Logo.Commands.UpdateLogo;
using Application.Features.Logo.Queries.GetLogo;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LogoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets logo.
        /// </summary>
        /// <returns>The getting logo result as LogoDTO.</returns>
        [HttpPost("GetLogo")]
        public async Task<LogoDTO> GetLogo()
        {
            var response = await _mediator.Send(new GetLogoQuery());
            return response;
        }

        /// <summary>
        /// Adds logo. 
        /// </summary>
        /// <param name="command">The command containing Base64(string), Text(string), AltText(string), Path(string) fields.</param>
        /// <returns>The adding logo result as ApiResponse.</returns>
        [HttpPost("AddLogo")]
        public async Task<ApiResponse> AddLogo(AddLogoCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Removes logo.
        /// </summary>
        /// <param name="command">The command containing no fields currently.</param>
        /// <returns>The removing logo result as ApiResponse</returns>
        [HttpPost("RemoveLogo")]
        public async Task<ApiResponse> RemoveLogo(RemoveLogoCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Updates logo.
        /// </summary>
        /// <param name="command">The command containing Base64(string), Text(string), AltText(string), Path(string) fields.</param>
        /// <returns>The updating logo result as ApiResponse.</returns>
        [HttpPost("UpdateLogo")]
        public async Task<ApiResponse> UpdateLogo(UpdateLogoCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

    }
}
