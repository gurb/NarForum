﻿
namespace AdminUI.Models.Stat
{
    public class AllStatsResponseVM
    {
        public StatsResponseVM? PostStats { get; set; } = new StatsResponseVM();
        public StatsResponseVM? CategoryStats { get; set; } = new StatsResponseVM();
        public StatsResponseVM? HeadingStats { get; set; } = new StatsResponseVM();
        public StatsResponseVM? SectionStats { get; set; } = new StatsResponseVM();
    }
}
