using AutoMapper;
using NarForumAdmin.Contracts;
using NarForumAdmin.Models.Category;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Services.Common;
using NarForumAdmin.Models;

namespace NarForumAdmin.Services
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
            try
            {
                var categories = await _client.CategoriesAllAsync();
                var data = _mapper.Map<List<CategoryVM>>(categories);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<CategoryVM>> GetCategoriesByName(string CategoryName)
        {
            try
            {
                var categories = await _client.GetCategoriesByNameAsync(CategoryName);
                var data = _mapper.Map<List<CategoryVM>>(categories);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<CategoryVM> GetCategoryByName(string CategoryName)
        {
            try
            {
                var category = await _client.GetCategoryByNameAsync(CategoryName);
                var data = _mapper.Map<CategoryVM>(category);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<CategoryVM>> GetParentCategoriesByIntId(int CategoryId)
        {
            try
            {
                var categories = await _client.GetParentCategoriesByIntIdAsync(CategoryId);
                var data = _mapper.Map<List<CategoryVM>>(categories);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<CategoryVM>> GetSectionCategories()
        {
            try
            {
                var categories = await _client.GetSectionCategoriesAsync();
                var data = _mapper.Map<List<CategoryVM>>(categories);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<CategoriesPaginationVM> GetCategoriesWithPagination(CategoriesPaginationQueryVM paramQuery)
        {
            try
            {
                GetCategoriesWithPaginationQuery query = _mapper.Map<GetCategoriesWithPaginationQuery>(paramQuery);

                var categoriesPagination = await _client.GetCategoriesWithPaginationAsync(query);

                var data = _mapper.Map<CategoriesPaginationVM>(categoriesPagination);

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task RemoveCategory(RemoveCategoryCommandVM category)
        {
            try
            {
                RemoveCategoryCommand command = _mapper.Map<RemoveCategoryCommand>(category);
                await _client.RemoveCategoryAsync(command);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ApiResponseVM> UpdateCategory(UpdateCategoryCommandVM category)
        {
            try
            {
                var updateCategoryCommand = _mapper.Map<UpdateCategoryCommand>(category);
                var data = await _client.UpdateCategoryAsync(updateCategoryCommand);

                return _mapper.Map<ApiResponseVM>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
