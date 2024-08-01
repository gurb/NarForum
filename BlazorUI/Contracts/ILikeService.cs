using BlazorUI.Models.Category;
using BlazorUI.Models.Like;
using BlazorUI.Services.Base;

namespace BlazorUI.Contracts
{
    public interface ILikeService
    {
        Task<List<LikeVM>> GetLikes();
        Task<List<LikeVM>> GetLikesByHeadingId(Guid headingId);
        Task<List<LikeVM>> GetLikesByUserName(string username);

        Task<ApiResponse<Guid>> AddLike(LikeVM like);
    }
}
