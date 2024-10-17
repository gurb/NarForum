using Application.Features.Favorite.Queries.GetFavorites;


namespace Application.Features.Favorite.Queries.GetFavoritesWithPagination
{
    public class FavoritesPaginationDTO
    {
        public List<FavoriteDTO>? Favorites { get; set; }
        public int TotalCount { get; set; }
    }
}
