using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Favorite.Commands.AddFavorite
{
    public class AddFavoriteCommand : IRequest<int>
    {
        public int? HeadingId { get; set; }
        public int? PostId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime? DateTime { get; set; }
    }
}
