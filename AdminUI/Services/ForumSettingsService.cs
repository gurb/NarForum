using AdminUI.Contracts;
using AdminUI.Models;
using AdminUI.Models.ForumSettings;
using AdminUI.Services.Base;
using AdminUI.Services.Common;
using AutoMapper;

namespace AdminUI.Services
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
            var forumSettings = await _client.GetForumSettingsAsync();
            var data = _mapper.Map<ForumSettingsVM>(forumSettings);

            return data;
        }

        public async Task<ApiResponseVM> UpdateForumSettings(UpdateForumSettingsCommandVM req)
        {
            var command = _mapper.Map<UpdateForumSettingsCommand>(req);
            var data = await _client.UpdateForumSettingsAsync(command);

            return _mapper.Map<ApiResponseVM>(data);
        }
    }
}
