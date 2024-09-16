using AutoMapper;
using BlazorUI.Contracts;
using BlazorUI.Models.ForumSettings;
using BlazorUI.Services.Base;
using BlazorUI.Services.Common;

namespace BlazorUI.Services
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
