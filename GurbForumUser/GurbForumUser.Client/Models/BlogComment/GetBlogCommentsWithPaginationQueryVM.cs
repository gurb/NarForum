namespace GurbForumUser.Client.Models.BlogComment;

public class GetBlogCommentsWithPaginationQueryVM
{
    public Guid? BlogPostId { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}
