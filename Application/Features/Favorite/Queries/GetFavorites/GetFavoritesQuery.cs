using MediatR;

namespace Application.Features.Favorite.Queries.GetFavorites
{
    public class GetFavoritesQuery : IRequest<List<FavoriteDTO>>
    {
        public Guid PostId { get; set; }
        public Guid HeadingId { get; set; }
        public string? UserName { get; set; }
    }
}
