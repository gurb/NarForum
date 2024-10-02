using GurbForumUser.Client.Contracts;
using GurbForumUser.Client.Models.SmtpSettings;
using GurbForumUser.Client.Services.Base;
using GurbForumUser.Client.Services.Common;
using AutoMapper;

namespace GurbForumUser.Client.Services
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
    }
}
