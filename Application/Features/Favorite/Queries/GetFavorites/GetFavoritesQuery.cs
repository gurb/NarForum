using MediatR;

namespace Application.Features.Favorite.Queries.GetFavorites
{
    public class GetFavoritesQuery : IRequest<List<FavoriteDTO>>
    {
        public int? PostId { get; set; }
        public int? HeadingId { get; set; }
        public string? UserName { get; set; }
    }
}
