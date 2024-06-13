using AdminUI.Contracts;
using AdminUI.Models;
using AdminUI.Models.Stat;
using AdminUI.Services.Base;
using AdminUI.Services.Common;
using AutoMapper;

namespace AdminUI.Services
{
    public class ForumStatService : BaseHttpService, IForumStatService
    {
        private readonly IMapper _mapper;
        public ForumStatService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<AllStatsResponseVM> GetAllStats()
        {
            var response = await _client.GetAllStatsAsync();

            return _mapper.Map<AllStatsResponseVM>(response);
        }

        public async Task<StatsResponseVM> GetCategoryStats()
        {
            var response = await _client.GetCategoryStatsAsync();

            return _mapper.Map<StatsResponseVM>(response);
        }

        public async Task<StatsResponseVM> GetHeadingStats()
        {
            var response = await _client.GetHeadingStatsAsync();

            return _mapper.Map<StatsResponseVM>(response);
        }

        public async Task<StatsResponseVM> GetPostStats()
        {
            var response = await _client.GetPostStatsAsync();

            return _mapper.Map<StatsResponseVM>(response);
        }

        public async Task<StatsResponseVM> GetSectionStats()
        {
            var response = await _client.GetSectionStatsAsync();

            return _mapper.Map<StatsResponseVM>(response);
        }
    }
}
