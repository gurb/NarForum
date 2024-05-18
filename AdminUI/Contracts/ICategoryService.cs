﻿using AdminUI.Models.Category;
using AdminUI.Services.Base;

namespace AdminUI.Contracts
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
        Task<ApiResponse<Guid>> CreateCategory(CategoryVM post);
    }
}