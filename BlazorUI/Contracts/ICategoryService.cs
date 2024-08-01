using BlazorUI.Models;
using BlazorUI.Models.Category;

namespace BlazorUI.Contracts
{
    public interface ICategoryService
    {
        // queries
        Task<CategoryVM> GetCategoryByName(string CategoryName);
        Task<List<CategoryVM>> GetCategories();
        Task<List<CategoryVM>> GetSectionCategories();
        Task<List<CategoryVM>> GetCategoriesByName(string CategoryName);
        Task<List<CategoryVM>> GetParentCategoriesByName(string CategoryName);

        // commands
        Task<ApiResponseVM> CreateCategory(CategoryVM post);
    }
}
