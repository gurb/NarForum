using NarForumAdmin.Contracts;
using NarForumAdmin.Models;
using NarForumAdmin.Models.ForumSettings;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using AutoMapper;

namespace NarForumAdmin.Services
{
    
    public class ForumSettingsService : BaseHttpService, IForumSettingsService
    {
        private readonly IMapper _mapper;
        public ForumSettingsService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ForumSettingsVM> GetForumSettings()
        {
            try
            {
                var forumSettings = await _client.GetForumSettingsAsync();
                var data = _mapper.Map<ForumSettingsVM>(forumSettings);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> UpdateForumSettings(UpdateForumSettingsCommandVM req)
        {
            try
            {
                var command = _mapper.Map<UpdateForumSettingsCommand>(req);
                var data = await _client.UpdateForumSettingsAsync(command);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
