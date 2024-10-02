using AutoMapper;
using GurbForumUser.Client.Contracts;
using GurbForumUser.Client.Models.Category;
using GurbForumUser.Client.Models.Like;
using GurbForumUser.Client.Services.Base;
using GurbForumUser.Client.Services.Common;

namespace GurbForumUser.Client.Services
{
    public class LikeService : BaseHttpService, ILikeService
    {
        private readonly IMapper _mapper;
        public LikeService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> AddLike(LikeVM like)
        {
            try
            {
                var command = _mapper.Map<AddLikeCommand>(like);
                await _client.AddLikeAsync(command);
                return new ApiResponse<Guid>
                {
                    Success = true
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<List<LikeVM>> GetLikes()
        {
            var likes = await _client.GetLikesAsync();
            var data = _mapper.Map<List<LikeVM>>(likes);

            return data;
        }

        public async Task<List<LikeVM>> GetLikesByHeadingId(Guid headingId)
        {
            var likes = await _client.GetLikesByHeadingIdAsync(headingId);
            var data = _mapper.Map<List<LikeVM>>(likes);

            return data;
        }

        public async Task<List<LikeVM>> GetLikesByUserName(string username)
        {
            var likes = await _client.GetLikesByUserNameAsync(username);
            var data = _mapper.Map<List<LikeVM>>(likes);

            return data;
        }
    }
}
