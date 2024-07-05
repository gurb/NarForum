using Application.Features.BlogCategory.Queries.GetBlogCategories;

namespace Application.Features.BlogPost.Queries.GetBlogPosts;

public class BlogPostDTO
{
    public BlogCategoryDTO? BlogCategory { get; set; }
    public int? BlogCategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public int ViewCounter { get; set; }
}
