using BlazorUI.Models;
using BlazorUI.Models.Category;

namespace BlazorUI.Contracts
{
    public interface ICategoryService
    {
        // queries
        Task<CategoryVM> GetCategoryByName(string CategoryName);
        Task<CategoryVM> GetCategoryByIntId(int CategoryId);
        Task<List<CategoryVM>> GetCategoriesById(Guid guid);
        Task<List<CategoryVM>> GetCategories();
        Task<List<CategoryVM>> GetSectionCategories();
        Task<List<CategoryVM>> GetCategoriesByName(string CategoryName);
        Task<List<CategoryVM>> GetParentCategoriesByIntId(int CategoryId);

        // commands
        Task<ApiResponseVM> CreateCategory(CategoryVM post);
    }
}
