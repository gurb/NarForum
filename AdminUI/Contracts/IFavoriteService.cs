using AdminUI.Models.Favorite;
using AdminUI.Services.Base;

namespace AdminUI.Contracts
{
    public interface IFavoriteService
    {
        Task<List<FavoriteVM>> GetFavorites();
        Task<List<FavoriteVM>> GetFavoritesByHeadingId(string headingId);
        Task<List<FavoriteVM>> GetFavoritesByUserName(string username);
        Task<List<FavoriteVM>> GetFavoritesByHeadingIdAndUserName(string headingId, string username);

        Task<ApiResponse<Guid>> AddFavorite(FavoriteVM like);
    }
}
