using AutoMapper;
using NarForumUser.Client.Contracts;
using NarForumUser.Client.Models;
using NarForumUser.Client.Models.Post;
using NarForumUser.Client.Services.Base;
using NarForumUser.Client.Services.Common;

namespace NarForumUser.Client.Services
{
    public class PostService: BaseHttpService, IPostService
    {
        private readonly IMapper _mapper;

        public PostService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage) 
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> CreatePost(PostVM post)
        {
            var createPostCommand = _mapper.Map<CreatePostCommand>(post);
            var response = await _client.PostsAsync(createPostCommand);
            return _mapper.Map<ApiResponseVM>(response);
        }

        public async Task<List<PostVM>> GetPosts()
        {
            var posts = await _client.PostsAllAsync();
            var data = _mapper.Map<List<PostVM>>(posts);

            return data;
        }

        public async Task<List<PostVM>> GetPostsByHeadingId(Guid id)
        {
            var posts = await _client.GetPostsByHeadingIdAsync(id);
            var data = _mapper.Map<List<PostVM>>(posts);

            return data;
        }

        public async Task<PostsPaginationVM> GetPostsByHeadingIdWithPagination(Guid id, int pageIndex, int pageSize)
        {
            var postsPagination = await _client.GetPostsByHeadingIdWithPaginationAsync(id, pageIndex, pageSize);

            var data = _mapper.Map<PostsPaginationVM>(postsPagination);

            return data;
        }

        public async Task<PostsPaginationVM> GetPostsByUserNameWithPagination(string userName, int pageIndex, int pageSize)
        {
            var postsPagination = await _client.GetPostsByUserNameWithPaginationAsync(userName, pageIndex, pageSize);

            var data = _mapper.Map<PostsPaginationVM>(postsPagination);

            return data;
        }
    }
}
