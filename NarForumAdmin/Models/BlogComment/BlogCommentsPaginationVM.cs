namespace NarForumAdmin.Models.BlogComment;

public class BlogCommentsPaginationVM
{
    public List<BlogCommentVM>? BlogComments { get; set; }
    public int TotalCount { get; set; }
}
