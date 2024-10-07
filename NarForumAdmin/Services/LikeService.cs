using AutoMapper;
using NarForumAdmin.Contracts;
using NarForumAdmin.Models.Category;
using NarForumAdmin.Models.Like;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;

namespace NarForumAdmin.Services
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
            try
            {
                var likes = await _client.GetLikesAsync();
                var data = _mapper.Map<List<LikeVM>>(likes);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<LikeVM>> GetLikesByHeadingId(Guid headingId)
        {
            
            try
            {
                var likes = await _client.GetLikesByHeadingIdAsync(headingId);
                var data = _mapper.Map<List<LikeVM>>(likes);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<LikeVM>> GetLikesByUserName(string username)
        {
            
            try
            {
                var likes = await _client.GetLikesByUserNameAsync(username);
                var data = _mapper.Map<List<LikeVM>>(likes);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
