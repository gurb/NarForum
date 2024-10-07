using NarForumAdmin.Models.Like;
using NarForumAdmin.Services.Base;

namespace NarForumAdmin.Contracts
{
    public interface ILikeService
    {
        Task<List<LikeVM>> GetLikes();
        Task<List<LikeVM>> GetLikesByHeadingId(Guid headingId);
        Task<List<LikeVM>> GetLikesByUserName(string username);

        Task<ApiResponse<Guid>> AddLike(LikeVM like);
    }
}
