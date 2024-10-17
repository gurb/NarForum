using MediatR;

namespace Application.Features.Favorite.Queries.GetFavoritesWithPagination
{
    public class GetFavoritesWithPaginationQuery : IRequest<FavoritesPaginationDTO>
    {
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
