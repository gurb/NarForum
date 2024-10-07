using NarForumUser.Client.Models.Category;
using NarForumUser.Client.Models.Favorite;
using NarForumUser.Client.Models.Like;
using NarForumUser.Client.Services.Base;

namespace NarForumUser.Client.Contracts
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
