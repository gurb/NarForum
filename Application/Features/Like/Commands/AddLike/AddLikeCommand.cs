using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Like.Commands.AddLike
{
    public class AddLikeCommand : IRequest<int>
    {
        public string? UserName { get; set; }
        public int? PostId { get; set; }
        public int? HeadingId { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public bool? IsLike { get; set; }
    }
}
