using NarForumAdmin.Contracts;
using NarForumAdmin.Models;
using NarForumAdmin.Models.BlogCategory;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using AutoMapper;

namespace NarForumAdmin.Services
{
    public class BlogCategoryService : BaseHttpService, IBlogCategoryService
    {
        private readonly IMapper _mapper;
        public BlogCategoryService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> AddBlogCategory(CreateBlogCategoryCommandVM command)
        {
            try
            {
                var createBlogCategoryCommand = _mapper.Map<CreateBlogCategoryCommand>(command);
                var data = await _client.AddBlogCategoryAsync(createBlogCategoryCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<BlogCategoryVM>> GetBlogCategories(GetBlogCategoriesQueryVM request)
        {
            try
            {
                var query = _mapper.Map<GetBlogCategoriesQuery>(request);
                var data = await _client.GetBlogCategoriesAsync(query);

                return _mapper.Map<List<BlogCategoryVM>>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<BlogCategoryVM> GetBlogCategory(GetBlogCategoryQueryVM request)
        {
            try
            {
                var query = _mapper.Map<GetBlogCategoryQuery>(request);
                var data = await _client.GetBlogCategoryAsync(query);

                return _mapper.Map<BlogCategoryVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> RemoveBlogCategory(RemoveBlogCategoryCommandVM command)
        {
            try
            {
                var removeBlogCategoryCommand = _mapper.Map<RemoveBlogCategoryCommand>(command);
                var data = await _client.RemoveBlogCategoryAsync(removeBlogCategoryCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> UpdateBlogCategory(UpdateBlogCategoryCommandVM command)
        {
            try
            {
                var updateBlogCategoryCommand = _mapper.Map<UpdateBlogCategoryCommand>(command);
                var data = await _client.UpdateBlogCategoryAsync(updateBlogCategoryCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
