using GurbForumUser.Client.Contracts;
using GurbForumUser.Client.Models;
using GurbForumUser.Client.Models.BlogComment;
using GurbForumUser.Client.Services.Base;
using GurbForumUser.Client.Services.Common;
using AutoMapper;

namespace GurbForumUser.Client.Services
{
    public class BlogCommentService : BaseHttpService, IBlogCommentService
    {
        private readonly IMapper _mapper;
        public BlogCommentService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> CreateBlogComment(CreateBlogCommentCommandVM command)
        {
            var createBlogCommentCommand = _mapper.Map<CreateBlogCommentCommand>(command);
            var data = await _client.CreateBlogCommentAsync(createBlogCommentCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<List<BlogCommentVM>> GetBlogComments(GetBlogCommentsQueryVM request)
        {
            var query = _mapper.Map<GetBlogCommentsQuery>(request);
            var data = await _client.BlogCommentsAsync(query);

            return _mapper.Map<List<BlogCommentVM>>(data);
        }

        public async Task<BlogCommentsPaginationVM> GetBlogCommentsWithPagination(GetBlogCommentsWithPaginationQueryVM request)
        {
            GetBlogCommentsWithPaginationQuery query = _mapper.Map<GetBlogCommentsWithPaginationQuery>(request);

            var commentsPagination = await _client.GetBlogCommentsWithPaginationAsync(query);

            var data = _mapper.Map<BlogCommentsPaginationVM>(commentsPagination);

            return data;
        }

        public async Task<ApiResponseVM> RemoveBlogComment(RemoveBlogCommentCommandVM command)
        {
            var removeBlogCommentCommand = _mapper.Map<RemoveBlogCommentCommand>(command);
            var data = await _client.RemoveBlogCommentAsync(removeBlogCommentCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<ApiResponseVM> UpdateBlogComment(UpdateBlogCommentCommandVM command)
        {
            var updateBlogCommentCommand = _mapper.Map<UpdateBlogCommentCommand>(command);
            var data = await _client.UpdateBlogCommentAsync(updateBlogCommentCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }
    }
}
