using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Persistence.Stats
{
    public class MonthStatDTO
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string? MonthName { get; set; }
        public int Counter { get; set; }
    }
}
