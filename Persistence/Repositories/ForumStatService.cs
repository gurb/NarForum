using Application.Contracts.Persistence;
using Application.Models.Persistence.Stats;
using Domain;
using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System.Globalization;


namespace Persistence.Repositories
{
    public class ForumStatService : IForumStatService
    {
        protected readonly ForumDbContext _context;

        public ForumStatService(ForumDbContext context)
        {
            _context = context;
        }

        public async Task<AllStatsResponse> GetAllStats()
        {
            AllStatsResponse response = new AllStatsResponse();

            response.PostStats = await GetPostStats();
            response.HeadingStats = await GetHeadingStats();
            response.SectionStats = await GetSectionStats();
            response.CategoryStats = await GetCategoryStats();

            return response;
        }

        public async Task<StatsResponse> GetCategoryStats()
        {
            return await GetEntityStats<Category>();
        }

        public async Task<StatsResponse> GetHeadingStats()
        {
            return await GetEntityStats<Heading>();
        }

        public async Task<StatsResponse> GetPostStats()
        {
            return await GetEntityStats<Post>();
        }

        public async Task<StatsResponse> GetSectionStats()
        {
            return await GetEntityStats<Section>();
        }

        public async Task<StatsResponse> GetEntityStats<T>() where T : BaseEntity
        {
            StatsResponse response = new StatsResponse();

            response.TotalCount = await _context.Set<T>().AsNoTracking().CountAsync();

            response.TodayStat = new StatWithDateDTO()
            {
                DateTime = DateTime.UtcNow.Date,
                Counter = await _context.Set<T>().AsNoTracking().Where(x => DateTime.UtcNow.Date == x.DateCreate).CountAsync()
            };

            var yesterday = DateTime.UtcNow.Date.AddDays(-1);

            response.YesterdayStat = new StatWithDateDTO()
            {
                DateTime = yesterday,
                Counter = await _context.Set<T>().AsNoTracking().Where(x => yesterday.Date == x.DateCreate).CountAsync()
            };

            response.MonthStats = _context.Set<T>().AsNoTracking()
                .GroupBy(k => new { Month = k.DateCreate.Value.Month, Year = k.DateCreate.Value.Year })
                .Select(g => new MonthStatDTO
                {
                    Month = g.Key.Month,
                    Year = g.Key.Year,
                    MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month),
                    Counter = g.ToList().Count()
                }).ToList();

            return response;
        }
    }
}
