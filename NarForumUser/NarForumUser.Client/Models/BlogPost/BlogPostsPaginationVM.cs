namespace NarForumUser.Client.Models.BlogPost;

public class BlogPostsPaginationVM
{
    public List<BlogPostVM>? BlogPosts { get; set; }
    public int TotalCount { get; set; }
}
