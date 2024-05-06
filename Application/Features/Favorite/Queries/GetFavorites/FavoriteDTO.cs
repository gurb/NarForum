using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Favorite.Queries.GetFavorites
{
    public class FavoriteDTO
    {
        public int Id { get; set; }
        public int? HeadingId { get; set; }
        public int? PostId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime? DateTime { get; set; }
    }
}
