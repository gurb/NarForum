using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;


namespace Application.Features.SmtpSetting.Queries
{
	public class GetSmtpSettingsQueryHandler : IRequestHandler<GetSmtpSettingsQuery, SmtpSettingsDTO>
	{

		private readonly IMapper _mapper;
		private readonly ISmtpSettingsService _settingsService;

		public GetSmtpSettingsQueryHandler(IMapper mapper, ISmtpSettingsService settingsService)
		{
			_mapper = mapper;
			_settingsService = settingsService;
		}

		public async Task<SmtpSettingsDTO> Handle(GetSmtpSettingsQuery request, CancellationToken cancellationToken)
		{
			var data = await _settingsService.GetAsync();

			if (data != null)
			{
				return _mapper.Map<SmtpSettingsDTO>(data);
			}
			else
			{
				return new SmtpSettingsDTO();
			}
		}
	}
}
