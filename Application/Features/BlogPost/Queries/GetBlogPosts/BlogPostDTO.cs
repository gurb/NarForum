using Application.Features.BlogCategory.Queries.GetBlogCategories;

namespace Application.Features.BlogPost.Queries.GetBlogPosts;

public class BlogPostDTO
{
    public Guid? Id { get; set; }
    public int BlogPostId { get; set; }
    public BlogCategoryDTO? BlogCategory { get; set; }
    public Guid? BlogCategoryId { get; set; }
	public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public Guid? UserId { get; set; }
    public int ViewCounter { get; set; }

    public DateTime? DateCreate { get; set; }

}
