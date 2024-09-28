using AutoMapper;
using AdminUI.Contracts;
using AdminUI.Models.Category;
using AdminUI.Services.Base;
using AdminUI.Services.Common;
using AdminUI.Models;

namespace AdminUI.Services
{
    public class CategoryService : BaseHttpService, ICategoryService
    {
        private readonly IMapper _mapper;
        public CategoryService(IClient client, IMapper mapper, LocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateCategory(CategoryVM post)
        {
            try
            {
                var createCategoryCommand = _mapper.Map<CreateCategoryCommand>(post);
                await _client.CategoriesAsync(createCategoryCommand);
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

        public async Task<List<CategoryVM>> GetCategories()
        {
            var categories = await _client.CategoriesAllAsync();
            var data = _mapper.Map<List<CategoryVM>>(categories);

            return data;
        }

        public async Task<List<CategoryVM>> GetCategoriesByName(string CategoryName)
        {
            var categories = await _client.GetCategoriesByNameAsync(CategoryName);
            var data = _mapper.Map<List<CategoryVM>>(categories);

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

        public async Task<CategoriesPaginationVM> GetCategoriesWithPagination(CategoriesPaginationQueryVM paramQuery)
        {
            GetCategoriesWithPaginationQuery query = _mapper.Map<GetCategoriesWithPaginationQuery>(paramQuery);

            var categoriesPagination = await _client.GetCategoriesWithPaginationAsync(query);

            var data = _mapper.Map<CategoriesPaginationVM>(categoriesPagination);

            return data;
        }

        public async Task RemoveCategory(RemoveCategoryCommandVM category)
        {
            RemoveCategoryCommand command = _mapper.Map<RemoveCategoryCommand>(category);
            await _client.RemoveCategoryAsync(command);
        }

        public async Task<ApiResponseVM> UpdateCategory(UpdateCategoryCommandVM category)
        {
            var updateCategoryCommand = _mapper.Map<UpdateCategoryCommand>(category);
            var data = await _client.UpdateCategoryAsync(updateCategoryCommand);

            return _mapper.Map<ApiResponseVM>(data);
        }
    }
}
