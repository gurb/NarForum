using AdminUI.Models.Like;
using AdminUI.Services.Base;

namespace AdminUI.Contracts
{
    public interface ILikeService
    {
        Task<List<LikeVM>> GetLikes();
        Task<List<LikeVM>> GetLikesByHeadingId(int headingId);
        Task<List<LikeVM>> GetLikesByUserName(string username);

        Task<ApiResponse<Guid>> AddLike(LikeVM like);
    }
}
