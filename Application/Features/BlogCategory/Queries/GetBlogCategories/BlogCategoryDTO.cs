namespace Application.Features.BlogCategory.Queries.GetBlogCategories
{
    public class BlogCategoryDTO
    {
        public Guid? Id { get; set; }
		public string Name { get; set; } = string.Empty;
    }
}
