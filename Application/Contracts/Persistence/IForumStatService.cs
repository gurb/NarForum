using Application.Models.Persistence.Stats;

namespace Application.Contracts.Persistence
{
    public interface IForumStatService
    {
        public Task<AllStatsResponse> GetAllStats();
        public Task<StatsResponse> GetPostStats();
        public Task<StatsResponse> GetCategoryStats();
        public Task<StatsResponse> GetHeadingStats();
        public Task<StatsResponse> GetSectionStats();
    }
}
