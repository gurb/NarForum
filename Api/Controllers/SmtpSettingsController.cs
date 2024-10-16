using Application.Features.SmtpSetting.Commands.UpdateSmtpSettings;
using Application.Features.SmtpSetting.Queries;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SmtpSettingsController : ControllerBase
	{
		private readonly IMediator _mediator;
		public SmtpSettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

		/// <summary>
		/// Gets SMTP Settings.
		/// </summary>
		/// <returns>The getting SMTP Settings result as SmtpSettingsDTO.</returns>
		[HttpPost("GetSmtpSettings")]
		public async Task<SmtpSettingsDTO> GetSmtpSettings()
		{
			var response = await _mediator.Send(new GetSmtpSettingsQuery());
			return response;
		}

        /// <summary>
        /// Updates SMTP Settings.
        /// </summary>
        /// <param name="command">The command containing Server(string), Port(int), UserName(string), Password(string), Timeout(int).</param>
        /// <returns>The updating SMTP settings result as ApiResponse.</returns>
        [HttpPost("UpdateSmtpSettings")]
		public async Task<ApiResponse> UpdateSmtpSettings(UpdateSmtpSettingsCommand command)
		{
			var response = await _mediator.Send(command);
			return response;
		}
	}
}
