using NarForumAdmin.Models.Favorite;
using NarForumAdmin.Services.Base;

namespace NarForumAdmin.Contracts
{
    public interface IFavoriteService
    {
        Task<List<FavoriteVM>> GetFavorites();
        Task<List<FavoriteVM>> GetFavoritesByHeadingId(Guid headingId);
        Task<List<FavoriteVM>> GetFavoritesByUserName(string username);
        Task<List<FavoriteVM>> GetFavoritesByHeadingIdAndUserName(Guid headingId, string username);

        Task<ApiResponse<Guid>> AddFavorite(FavoriteVM like);
    }
}
