using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Like.Queries.GetLikes
{
    public class LikeDTO
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public Guid HeadingId { get; set; }
        public Guid PostId { get; set; }
        public DateTime DateTime { get; set; }
        public bool? IsLike { get; set; }
    }
}
