﻿using AutoMapper;
using AdminUI.Contracts;
using AdminUI.Models.Category;
using AdminUI.Models.Heading;
using AdminUI.Services.Base;
using AdminUI.Services.Common;

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

        public async Task<List<CategoryVM>> GetParentCategoriesByName(string CategoryName)
        {
            var categories = await _client.GetParentCategoriesByNameAsync(CategoryName);
            var data = _mapper.Map<List<CategoryVM>>(categories);

            return data;
        }

        public async Task<List<CategoryVM>> GetSectionCategories()
        {
            var categories = await _client.GetSectionCategoriesAsync();
            var data = _mapper.Map<List<CategoryVM>>(categories);

            return data;
        }
    }
}