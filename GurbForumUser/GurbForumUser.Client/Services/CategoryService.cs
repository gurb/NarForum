using AutoMapper;
using GurbForumUser.Client.Contracts;
using GurbForumUser.Client.Models;
using GurbForumUser.Client.Models.Category;
using GurbForumUser.Client.Services.Base;
using GurbForumUser.Client.Services.Common;

namespace GurbForumUser.Client.Services
{
    public class CategoryService : BaseHttpService, ICategoryService
    {
        private readonly IMapper _mapper;
        public CategoryService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponseVM> CreateCategory(CategoryVM post)
        {
            var createCategoryCommand = _mapper.Map<CreateCategoryCommand>(post);
            var data = await _client.CategoriesAsync(createCategoryCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }

        public async Task<List<CategoryVM>> GetCategories()
        {
            var categories = await _client.CategoriesAllAsync();
            var data = _mapper.Map<List<CategoryVM>>(categories);

            return data;
        }

        public async Task<List<CategoryVM>> GetCategoriesById(Guid guid)
        {
            var categories = await _client.GetCategoriesByIdAsync(guid);
            var data = _mapper.Map<List<CategoryVM>>(categories);

            return data;
        }

        public async Task<List<CategoryVM>> GetCategoriesByName(string CategoryName)
        {
            var categories = await _client.GetCategoriesByNameAsync(CategoryName);
            var data = _mapper.Map<List<CategoryVM>>(categories);

            return data;

        }

        public async Task<CategoryVM> GetCategoryByIntId(int CategoryId)
        {
            var category = await _client.GetCategoryByIntIdAsync(CategoryId);
            var data = _mapper.Map<CategoryVM>(category);

            return data;
        }

        public async Task<CategoryVM> GetCategoryByName(string CategoryName)
        {
            var category = await _client.GetCategoryByNameAsync(CategoryName);
            var data = _mapper.Map<CategoryVM>(category);

            return data;
        }

        public async Task<List<CategoryVM>> GetParentCategoriesByIntId(int CategoryId)
        {
            var categories = await _client.GetParentCategoriesByIntIdAsync(CategoryId);
            var data = _mapper.Map<List<CategoryVM>>(categories);

            return data;
        }

        public async Task<List<CategoryVM>> GetSectionCategories()
        {
            var categories = await _client.GetSectionCategoriesAsync();
            var data = _mapper.Map<List<CategoryVM>>(categories);

            return data;
        }

        public async Task<ApiResponseVM> UpdateCategory(UpdateCategoryCommandVM category)
        {
            var updateCategoryCommand = _mapper.Map<UpdateCategoryCommand>(category);
            var data = await _client.UpdateCategoryAsync(updateCategoryCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }
    }
 }
