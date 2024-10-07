using NarForumUser.Client.Contracts;
using NarForumUser.Client.Models.SmtpSettings;
using NarForumUser.Client.Services.Base;
using NarForumUser.Client.Services.Common;
using AutoMapper;

namespace NarForumUser.Client.Services
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
