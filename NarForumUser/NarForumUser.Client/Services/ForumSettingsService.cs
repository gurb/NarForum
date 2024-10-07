using AutoMapper;
using NarForumUser.Client.Contracts;
using NarForumUser.Client.Models.ForumSettings;
using NarForumUser.Client.Services.Base;
using NarForumUser.Client.Services.Common;

namespace NarForumUser.Client.Services
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
