using NarForumAdmin.Contracts;
using NarForumAdmin.Models;
using NarForumAdmin.Models.Stat;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using AutoMapper;

namespace NarForumAdmin.Services
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
            try
            {
                var response = await _client.GetAllStatsAsync();

                return _mapper.Map<AllStatsResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<StatsResponseVM> GetCategoryStats()
        {
            try
            {
                var response = await _client.GetCategoryStatsAsync();

                return _mapper.Map<StatsResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<StatsResponseVM> GetHeadingStats()
        {
            
            try
            {
                var response = await _client.GetHeadingStatsAsync();

                return _mapper.Map<StatsResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<StatsResponseVM> GetPostStats()
        {
            try
            {
                var response = await _client.GetPostStatsAsync();

                return _mapper.Map<StatsResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<StatsResponseVM> GetSectionStats()
        {
            try
            {
                var response = await _client.GetSectionStatsAsync();

                return _mapper.Map<StatsResponseVM>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
