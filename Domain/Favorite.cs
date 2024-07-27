using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Favorite
    {
        public string? Id { get; set; }
        public string? HeadingId { get; set; }
        public string? PostId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime? DateTime { get; set; }
    }
}
