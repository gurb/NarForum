using BlazorUI.Models.Category;
using BlazorUI.Models.Favorite;
using BlazorUI.Models.Like;
using BlazorUI.Services.Base;

namespace BlazorUI.Contracts
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
