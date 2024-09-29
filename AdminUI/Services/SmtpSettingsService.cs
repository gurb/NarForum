using AdminUI.Contracts;
using AdminUI.Models;
using AdminUI.Models.SmtpSettings;
using AdminUI.Services.Base;
using AdminUI.Services.Common;
using AutoMapper;

namespace AdminUI.Services
{
    public class SmtpSettingsService : BaseHttpService, ISmtpSettingsService
    {
        private readonly IMapper _mapper;
        public SmtpSettingsService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<SmtpSettingsVM> GetSmtpSettings()
        {
            var forumSettings = await _client.GetSmtpSettingsAsync();
            var data = _mapper.Map<SmtpSettingsVM>(forumSettings);

            return data;
        }

        public async Task<ApiResponseVM> UpdateSmtpSettings(UpdateSmtpSettingsCommandVM req)
        {
            var command = _mapper.Map<UpdateSmtpSettingsCommand>(req);
            var data = await _client.UpdateSmtpSettingsAsync(command);

            return _mapper.Map<ApiResponseVM>(data);
        }
    }
}
