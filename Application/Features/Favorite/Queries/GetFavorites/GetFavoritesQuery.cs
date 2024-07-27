using MediatR;

namespace Application.Features.Favorite.Queries.GetFavorites
{
    public class GetFavoritesQuery : IRequest<List<FavoriteDTO>>
    {
        public string? PostId { get; set; }
        public string? HeadingId { get; set; }
        public string? UserName { get; set; }
    }
}
