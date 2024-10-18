using NarForumUser.Client.Services.Base;

namespace NarForumUser.Client.Models.Stat
{
    public class StatsResponseVM
    {
        public int TotalCount { get; set; }
        public StatWithDateVM? TodayStat { get; set; } = new StatWithDateVM();
        public StatWithDateVM? YesterdayStat { get; set; } = new StatWithDateVM();
        public List<MonthStatVM>? MonthStats { get; set; } = new List<MonthStatVM>();
    }
}
