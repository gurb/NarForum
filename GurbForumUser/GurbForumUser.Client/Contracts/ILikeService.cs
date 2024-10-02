using GurbForumUser.Client.Models.Category;
using GurbForumUser.Client.Models.Like;
using GurbForumUser.Client.Services.Base;

namespace GurbForumUser.Client.Contracts
{
    public interface ILikeService
    {
        Task<List<LikeVM>> GetLikes();
        Task<List<LikeVM>> GetLikesByHeadingId(Guid headingId);
        Task<List<LikeVM>> GetLikesByUserName(string username);

        Task<ApiResponse<Guid>> AddLike(LikeVM like);
    }
}
