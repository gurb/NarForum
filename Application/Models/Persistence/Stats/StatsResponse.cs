using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Persistence.Stats
{
    public class StatsResponse
    {
        public int TotalCount { get; set; }
        public StatWithDateDTO? TodayStat { get; set; }
        public StatWithDateDTO? YesterdayStat { get; set; }
        public List<MonthStatDTO>? MonthStats { get; set; }
    }
}
