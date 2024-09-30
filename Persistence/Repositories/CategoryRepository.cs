using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System.Collections.Generic;

namespace Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ForumDbContext context) : base(context)
        {

        }

        public async Task<Category> GetByName(string name)
        {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower() && x.IsActive);
        }

        public async Task<Category> GetByIntId(int id)
        {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryId == id && x.IsActive);
        }

        public async Task IncreasePostCounter(Guid HeadingId)
        {
            var heading = await _context.Headings.FirstOrDefaultAsync(x => x.Id == HeadingId);

            if (heading != null)
            {
                List<Domain.Category> categoryList = new List<Category>();
                var categories = await _context.Categories.Where(x => x.IsActive).ToListAsync();
                await IterateCategoryPostCounter(heading.CategoryId, categoryList, categories);

                _context.UpdateRange(categoryList);
                await _context.SaveChangesAsync();
            }
        }

        private async Task IterateCategoryPostCounter(Guid? categoryId, List<Domain.Category> list, List<Domain.Category> allCategories)
        {
            var category = allCategories.FirstOrDefault(x => x.Id == categoryId);

            if (category != null)
            {
                category.PostCounter++;
                list.Add(category);

                await IterateCategoryPostCounter(category.ParentCategoryId, list, allCategories);
            }
        }
        public async Task IncreaseHeadingCounter(Guid categoryId)
        {
            List<Domain.Category> categoryList = new List<Category>();
            var categories = await _context.Categories.Where(x => x.IsActive).ToListAsync();
            await IterateCategoryHeadingCounter(categoryId, categoryList, categories);

            _context.UpdateRange(categoryList);
            await _context.SaveChangesAsync();
        }

        private async Task IterateCategoryHeadingCounter(Guid? categoryId, List<Domain.Category> list, List<Domain.Category> allCategories)
        {
            var category = allCategories.FirstOrDefault(x => x.Id == categoryId);

            if (category != null)
            {
                category.HeadingCounter++;
                list.Add(category);

                await IterateCategoryHeadingCounter(category.ParentCategoryId, list, allCategories);
            }
        }

        public async Task UpdateCategoryWhenCreatePost(Guid categoryId, string lastUserName, Guid lastUserId, Guid lastHeadingId, Guid lastPostId)
        {
            List<Domain.Category> categoryList = new List<Category>();
            var categories = await _context.Categories.Where(x => x.IsActive).ToListAsync();
            await IterateUpdateCategoryWhenCreatePost(categoryId, lastUserName, lastUserId, lastHeadingId, lastPostId, categoryList, categories);

            _context.UpdateRange(categoryList);
            await _context.SaveChangesAsync();
        }

        private async Task IterateUpdateCategoryWhenCreatePost(Guid? categoryId, string lastUserName, Guid lastUserId, Guid lastHeadingId, Guid lastPostId, List<Domain.Category> list, List<Domain.Category> allCategories)
        {
            var category =  allCategories.FirstOrDefault(x => x.Id == categoryId && x.IsActive);

            if (category != null)
            {
                category.LastHeadingId = lastHeadingId;
                category.LastPostId = lastPostId;
                category.LastUserName = lastUserName;
                category.LastUserId = lastUserId;
                category.ActiveDate = DateTime.UtcNow;

                list.Add(category);

                if(category.ParentCategoryId != null)
                {
                    await IterateUpdateCategoryWhenCreatePost(category.ParentCategoryId, lastUserName, lastUserId, lastHeadingId, lastPostId, list, allCategories);
                }
            }
        }
    }
}
