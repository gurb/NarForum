using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Like.Commands.AddLike
{
    public class AddLikeCommand : IRequest<string>
    {
        public string? UserName { get; set; }
        public string? PostId { get; set; }
        public string? HeadingId { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public bool? IsLike { get; set; }
    }
}
