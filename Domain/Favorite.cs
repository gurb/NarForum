using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Favorite
    {
        public Guid Id { get; set; }
        public Guid HeadingId { get; set; }
        public Guid PostId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime? DateTime { get; set; }
    }
}
