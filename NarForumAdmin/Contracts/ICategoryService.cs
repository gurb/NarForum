using NarForumAdmin.Models;
using NarForumAdmin.Models.Category;
using NarForumAdmin.Services.Base;

namespace NarForumAdmin.Contracts
{
    public interface ICategoryService
    {
        // queries
        Task<CategoryVM> GetCategoryByName(string CategoryName);
        Task<List<CategoryVM>> GetCategories();
        Task<List<CategoryVM>> GetSectionCategories();
        Task<List<CategoryVM>> GetCategoriesByName(string CategoryName);
        Task<List<CategoryVM>> GetParentCategoriesByIntId(int CategoryId);
        Task<CategoriesPaginationVM> GetCategoriesWithPagination(CategoriesPaginationQueryVM paramQuery);

        // commands
        Task<ApiResponse<Guid>> CreateCategory(CategoryVM post);
        Task RemoveCategory(RemoveCategoryCommandVM category);
        Task<ApiResponseVM> UpdateCategory(UpdateCategoryCommandVM category);
    }
}
