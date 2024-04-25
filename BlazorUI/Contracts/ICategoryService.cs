using BlazorUI.Models.Category;
using BlazorUI.Services.Base;

namespace BlazorUI.Contracts
{
    public interface ICategoryService
    {
        // queries
        Task<List<CategoryVM>> GetCategories();

        // commands
        Task<ApiResponse<Guid>> CreateCategory(CategoryVM post);
    }
}
