using BlazorUI.Models.Category;
using BlazorUI.Services.Base;

namespace BlazorUI.Contracts
{
    public interface ICategoryService
    {
        // queries
        Task<CategoryVM> GetCategoryByName(string CategoryName);
        Task<List<CategoryVM>> GetCategories();
        Task<List<CategoryVM>> GetCategoriesByName(string CategoryName);

        // commands
        Task<ApiResponse<Guid>> CreateCategory(CategoryVM post);
    }
}
