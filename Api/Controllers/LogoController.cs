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

        [HttpPost("GetLogo")]
        public async Task<LogoDTO> GetLogo()
        {
            var response = await _mediator.Send(new GetLogoQuery());
            return response;
        }


        [HttpPost("AddLogo")]
        public async Task<ApiResponse> AddLogo(AddLogoCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("RemoveLogo")]
        public async Task<ApiResponse> RemoveLogo(RemoveLogoCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("UpdateLogo")]
        public async Task<ApiResponse> UpdateLogo(UpdateLogoCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

    }
}
