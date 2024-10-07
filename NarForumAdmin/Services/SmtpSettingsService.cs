using NarForumAdmin.Contracts;
using NarForumAdmin.Models;
using NarForumAdmin.Models.SmtpSettings;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using AutoMapper;

namespace NarForumAdmin.Services
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
            
            try
            {
                var forumSettings = await _client.GetSmtpSettingsAsync();
                var data = _mapper.Map<SmtpSettingsVM>(forumSettings);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> UpdateSmtpSettings(UpdateSmtpSettingsCommandVM req)
        {
            try
            {
                var command = _mapper.Map<UpdateSmtpSettingsCommand>(req);
                var data = await _client.UpdateSmtpSettingsAsync(command);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
