using NarForumUser.Client.Models.Stat;

namespace NarForumUser.Client.Contracts
{
    public interface IForumStatService
    {
        public Task<AllStatsResponseVM> GetAllStats();
        public Task<StatsResponseVM> GetPostStats();
        public Task<StatsResponseVM> GetCategoryStats();
        public Task<StatsResponseVM> GetHeadingStats();
        public Task<StatsResponseVM> GetSectionStats();
    }
}
