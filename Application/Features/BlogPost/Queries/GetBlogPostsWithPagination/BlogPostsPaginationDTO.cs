using Application.Features.BlogPost.Queries.GetBlogPosts;

namespace Application.Features.BlogPost.Queries.GetBlogPostsWithPagination;

public class BlogPostsPaginationDTO
{
    public List<BlogPostDTO>? BlogPosts { get; set; }
    public int TotalCount { get; set; }
}
