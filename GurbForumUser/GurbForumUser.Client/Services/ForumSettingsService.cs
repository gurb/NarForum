using AutoMapper;
using GurbForumUser.Client.Contracts;
using GurbForumUser.Client.Models.ForumSettings;
using GurbForumUser.Client.Services.Base;
using GurbForumUser.Client.Services.Common;

namespace GurbForumUser.Client.Services
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
            var logo = await _client.GetForumSettingsAsync();
            var data = _mapper.Map<ForumSettingsVM>(logo);

            return data;
        }
    }
}
