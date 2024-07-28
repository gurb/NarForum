using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Favorite.Queries.GetFavorites
{
    public class FavoriteDTO
    {
        public Guid Id { get; set; } = Guid.Empty;
		public Guid HeadingId { get; set; } = Guid.Empty;
		public Guid PostId { get; set; } = Guid.Empty;
		public string UserName { get; set; } = string.Empty;
        public DateTime? DateTime { get; set; }
    }
}
