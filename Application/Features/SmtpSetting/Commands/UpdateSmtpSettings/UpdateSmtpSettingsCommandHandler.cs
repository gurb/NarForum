using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;


namespace Application.Features.SmtpSetting.Commands.UpdateSmtpSettings
{
	
	public class UpdateSmtpSettingsCommandHandler : IRequestHandler<UpdateSmtpSettingsCommand, ApiResponse>
	{
		private readonly IMapper _mapper;
		private readonly ISmtpSettingsService _settingsService;

		public UpdateSmtpSettingsCommandHandler(IMapper mapper, ISmtpSettingsService settingsService)
		{
			_mapper = mapper;
			_settingsService = settingsService;
		}
		public async Task<ApiResponse> Handle(UpdateSmtpSettingsCommand request, CancellationToken cancellationToken)
		{
			ApiResponse response = new ApiResponse();

			try
			{
				var settings = await _settingsService.GetAsync();

				if (settings is null)
				{
					var data = new Domain.SmtpSettings
					{
						Server = request.Server,
						Username = request.Username,
						Password = request.Password,
						Port = request.Port,
						Timeout = request.Timeout,
					};
					await _settingsService.AddAsync(data);
					response.Message = "SMTP settings is saved";
				}
				else
				{
					var data = _mapper.Map<Domain.SmtpSettings>(settings);
					await _settingsService.UpdateAsync(data);
					response.Message = "SMTP settings is updated";
				}
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Message = ex.Message;
			}

			return response;
		}
	}
}
