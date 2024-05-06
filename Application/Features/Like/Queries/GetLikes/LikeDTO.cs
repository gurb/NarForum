using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Like.Queries.GetLikes
{
    public class LikeDTO
    {
        public int Id { get; set; }
        public int? UserName { get; set; }
        public int? PostId { get; set; }
        public DateTime DateTime { get; set; }
        public bool? IsLıke { get; set; }
    }
}
