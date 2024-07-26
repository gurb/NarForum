using BlazorUI.Contracts;
using BlazorUI.Models;
using BlazorUI.Models.BlogCategory;
using BlazorUI.Services.Base;
using BlazorUI.Services.Common;
using AutoMapper;

namespace BlazorUI.Services
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
            var createBlogCategoryCommand = _mapper.Map<CreateBlogCategoryCommand>(command);
            var data = await _client.AddBlogCategoryAsync(createBlogCategoryCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<List<BlogCategoryVM>> GetBlogCategories(GetBlogCategoriesQueryVM request)
        {
            var query = _mapper.Map<GetBlogCategoriesQuery>(request);
            var data = await _client.GetBlogCategoriesAsync(query);

            return _mapper.Map<List<BlogCategoryVM>>(data);
        }

        public async Task<BlogCategoryVM> GetBlogCategory(GetBlogCategoryQueryVM request)
        {
            var query = _mapper.Map<GetBlogCategoryQuery>(request);
            var data = await _client.GetBlogCategoryAsync(query);

            return _mapper.Map<BlogCategoryVM>(data);
        }

        public async Task<ApiResponseVM> RemoveBlogCategory(RemoveBlogCategoryCommandVM command)
        {
            var removeBlogCategoryCommand = _mapper.Map<RemoveBlogCategoryCommand>(command);
            var data = await _client.RemoveBlogCategoryAsync(removeBlogCategoryCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<ApiResponseVM> UpdateBlogCategory(UpdateBlogCategoryCommandVM command)
        {
            var updateBlogCategoryCommand = _mapper.Map<UpdateBlogCategoryCommand>(command);
            var data = await _client.UpdateBlogCategoryAsync(updateBlogCategoryCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }
    }
}
