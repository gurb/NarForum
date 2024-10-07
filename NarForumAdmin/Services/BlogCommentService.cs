using NarForumAdmin.Contracts;
using NarForumAdmin.Models;
using NarForumAdmin.Models.BlogComment;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using AutoMapper;

namespace NarForumAdmin.Services
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

            try
            {
                var createBlogCommentCommand = _mapper.Map<CreateBlogCommentCommand>(command);
                var data = await _client.CreateBlogCommentAsync(createBlogCommentCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<BlogCommentVM>> GetBlogComments(GetBlogCommentsQueryVM request)
        {
            try
            {
                var query = _mapper.Map<GetBlogCommentsQuery>(request);
                var data = await _client.BlogCommentsAsync(query);

                return _mapper.Map<List<BlogCommentVM>>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<BlogCommentsPaginationVM> GetBlogCommentsWithPagination(GetBlogCommentsWithPaginationQueryVM request)
        {
            try
            {
                GetBlogCommentsWithPaginationQuery query = _mapper.Map<GetBlogCommentsWithPaginationQuery>(request);

                var commentsPagination = await _client.GetBlogCommentsWithPaginationAsync(query);

                var data = _mapper.Map<BlogCommentsPaginationVM>(commentsPagination);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> RemoveBlogComment(RemoveBlogCommentCommandVM command)
        {
            try
            {
                var removeBlogCommentCommand = _mapper.Map<RemoveBlogCommentCommand>(command);
                var data = await _client.RemoveBlogCommentAsync(removeBlogCommentCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> UpdateBlogComment(UpdateBlogCommentCommandVM command)
        {
            try
            {
                var updateBlogCommentCommand = _mapper.Map<UpdateBlogCommentCommand>(command);
                var data = await _client.UpdateBlogCommentAsync(updateBlogCommentCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
