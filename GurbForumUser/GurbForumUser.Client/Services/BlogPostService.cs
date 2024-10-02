using GurbForumUser.Client.Contracts;
using GurbForumUser.Client.Models;
using GurbForumUser.Client.Models.BlogPost;
using GurbForumUser.Client.Services.Base;
using GurbForumUser.Client.Services.Common;
using AutoMapper;

namespace GurbForumUser.Client.Services
{
    public class BlogPostService : BaseHttpService, IBlogPostService
    {
        private readonly IMapper _mapper;

        public BlogPostService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> CreateBlogPost(CreateBlogPostCommandVM command)
        {
            var createBlogPostCommand = _mapper.Map<CreateBlogPostCommand>(command);
            var data = await _client.CreateBlogPostAsync(createBlogPostCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<ApiResponseVM> DraftBlogPost(DraftBlogPostCommandVM command)
        {
            var draftBlogPostCommand = _mapper.Map<DraftBlogPostCommand>(command);
            var data = await _client.DraftBlogPostAsync(draftBlogPostCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<BlogPostVM> GetBlogPost(GetBlogPostQueryVM request)
        {
            var query = _mapper.Map<GetBlogPostQuery>(request);
            var data = await _client.GetBlogPostAsync(query);

            return _mapper.Map<BlogPostVM>(data);
        }

        public async Task<List<BlogPostVM>> GetBlogPosts(GetBlogPostsQueryVM request)
        {
            var query = _mapper.Map<GetBlogPostsQuery>(request);
            var data = await _client.BlogPostsAsync(query);

            return _mapper.Map<List<BlogPostVM>>(data);
        }

        public async Task<BlogPostsPaginationVM> GetBlogPostsWithPagination(GetBlogPostsWithPaginationQueryVM request)
        {
            GetBlogPostsWithPaginationQuery query = _mapper.Map<GetBlogPostsWithPaginationQuery>(request);

            var postsPagination = await _client.GetBlogPostsWithPaginationAsync(query);

            var data = _mapper.Map<BlogPostsPaginationVM>(postsPagination);

            return data;
        }

        public async Task<ApiResponseVM> PublishBlogPost(PublishBlogPostCommandVM command)
        {
            var publishBlogPostCommand = _mapper.Map<PublishBlogPostCommand>(command);
            var data = await _client.PublishBlogPostAsync(publishBlogPostCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<ApiResponseVM> RemoveBlogPost(RemoveBlogPostCommandVM command)
        {
            var removeBlogPostCommand = _mapper.Map<RemoveBlogPostCommand>(command);
            var data = await _client.RemoveBlogPostAsync(removeBlogPostCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<ApiResponseVM> UpdateBlogPost(UpdateBlogPostCommandVM command)
        {
            var updateBlogPostCommand = _mapper.Map<UpdateBlogPostCommand>(command);
            var data = await _client.UpdateBlogPostAsync(updateBlogPostCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }
    }
}
