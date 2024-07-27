using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Like.Queries.GetLikes
{
    public class LikeDTO
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? HeadingId { get; set; }
        public string? PostId { get; set; }
        public DateTime DateTime { get; set; }
        public bool? IsLike { get; set; }
    }
}
