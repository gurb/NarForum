namespace Application.Models.Persistence.Stats
{
    public class AllStatsResponse
    {
        public StatsResponse? PostStats { get; set; }
        public StatsResponse? CategoryStats { get; set; }
        public StatsResponse? HeadingStats { get; set; }
        public StatsResponse? SectionStats { get; set; }
        public StatsResponse? UserStats { get; set; }

    }
}
