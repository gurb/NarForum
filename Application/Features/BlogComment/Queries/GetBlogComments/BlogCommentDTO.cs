using Application.Features.BlogPost.Queries.GetBlogPosts;

namespace Application.Features.BlogComment.Queries.GetBlogComments;

public class BlogCommentDTO
{
    public BlogPostDTO? BlogPost { get; set; }
    public Guid BlogPostId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}
