using NarForumUser.Client.Models.Category;
using NarForumUser.Client.Models.Like;
using NarForumUser.Client.Services.Base;

namespace NarForumUser.Client.Contracts
{
    public interface ILikeService
    {
        Task<List<LikeVM>> GetLikes();
        Task<List<LikeVM>> GetLikesByHeadingId(Guid headingId);
        Task<List<LikeVM>> GetLikesByUserName(string username);

        Task<ApiResponse<Guid>> AddLike(LikeVM like);
    }
}
