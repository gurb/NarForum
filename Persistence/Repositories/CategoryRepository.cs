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
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
        }

        

        public async Task IncreasePostCounter(int HeadingId)
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

        private async Task IterateCategoryPostCounter(int? categoryId, List<Domain.Category> list, List<Domain.Category> allCategories)
        {
            var category = allCategories.FirstOrDefault(x => x.Id == categoryId);

            if (category != null)
            {
                category.PostCounter++;
                list.Add(category);

                await IterateCategoryPostCounter(category.ParentCategoryId, list, allCategories);
            }
        }
        public async Task IncreaseHeadingCounter(int categoryId)
        {
            List<Domain.Category> categoryList = new List<Category>();
            var categories = await _context.Categories.Where(x => x.IsActive).ToListAsync();
            await IterateCategoryHeadingCounter(categoryId, categoryList, categories);

            _context.UpdateRange(categoryList);
            await _context.SaveChangesAsync();
        }

        private async Task IterateCategoryHeadingCounter(int? categoryId, List<Domain.Category> list, List<Domain.Category> allCategories)
        {
            var category = allCategories.FirstOrDefault(x => x.Id == categoryId);

            if (category != null)
            {
                category.HeadingCounter++;
                list.Add(category);

                await IterateCategoryHeadingCounter(category.ParentCategoryId, list, allCategories);
            }
        }

        public async Task UpdateCategoryWhenCreatePost(int categoryId, string lastUserName, int lastHeadingId,  int lastPostId)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);

            if (category != null)
            {
                category.LastHeadingId = lastHeadingId;
                category.LastPostId = lastPostId;
                category.LastUserName = lastUserName;
                category.ActiveDate = DateTime.UtcNow;

                _context.Update(category);
                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
