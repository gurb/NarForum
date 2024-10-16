using Application.Contracts.Persistence;
using Application.Models.Persistence.Stats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IForumStatService _forumStatService;

        public StatsController(IForumStatService forumStatService)
        {
            _forumStatService = forumStatService;
        }

        /// <summary>
        /// Gets all stats.
        /// </summary>
        /// <returns>The getting all stats result as AllStatsResponse.</returns>
        [HttpPost("GetAllStats")]
        public async Task<AllStatsResponse> GetAllStats()
        {
            return await _forumStatService.GetAllStats();
        }

        /// <summary>
        /// Gets post stats.
        /// </summary>
        /// <returns>The getting post stats result as StatsResponse.</returns>
        [HttpPost("GetPostStats")]
        public async Task<StatsResponse> GetPostStats()
        {
            return await _forumStatService.GetPostStats();
        }

        /// <summary>
        /// Gets category stats.
        /// </summary>
        /// <returns>The getting category stats result as StatsResponse.</returns>
        [HttpPost("GetCategoryStats")]
        public async Task<StatsResponse> GetCategoryStats()
        {
            return await _forumStatService.GetCategoryStats();
        }

        /// <summary>
        /// Gets heading stats.
        /// </summary>
        /// <returns>The getting heading stats result as StatsResponse.</returns>
        [HttpPost("GetHeadingStats")]
        public async Task<StatsResponse> GetHeadingStats()
        {
            return await _forumStatService.GetHeadingStats();
        }

        /// <summary>
        /// Gets section stats.
        /// </summary>
        /// <returns>The getting section stats result as StatsResponse.</returns>
        [HttpPost("GetSectionStats")]
        public async Task<StatsResponse> GetSectionStats()
        {
            return await _forumStatService.GetSectionStats();
        }
    }
}
