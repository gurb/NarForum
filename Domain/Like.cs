using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Like
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int? PostId { get; set; }
        public int? HeadingId { get; set; }
        public DateTime DateTime { get; set; }
        public bool? IsLike { get; set; }
    }
}
