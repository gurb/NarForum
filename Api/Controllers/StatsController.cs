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

        [HttpPost("GetAllStats")]
        public async Task<AllStatsResponse> GetAllStats()
        {
            return await _forumStatService.GetAllStats();
        }

        [HttpPost("GetPostStats")]
        public async Task<StatsResponse> GetPostStats()
        {
            return await _forumStatService.GetPostStats();
        }

        [HttpPost("GetCategoryStats")]
        public async Task<StatsResponse> GetCategoryStats()
        {
            return await _forumStatService.GetCategoryStats();
        }

        [HttpPost("GetHeadingStats")]
        public async Task<StatsResponse> GetHeadingStats()
        {
            return await _forumStatService.GetHeadingStats();
        }

        [HttpPost("GetSectionStats")]
        public async Task<StatsResponse> GetSectionStats()
        {
            return await _forumStatService.GetSectionStats();
        }
    }
}
