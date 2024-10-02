using GurbForumUser.Client.Models;
using GurbForumUser.Client.Models.BlogComment;

namespace GurbForumUser.Client.Contracts;

public interface IBlogCommentService
{
    Task<List<BlogCommentVM>> GetBlogComments(GetBlogCommentsQueryVM request);
    Task<BlogCommentsPaginationVM> GetBlogCommentsWithPagination(GetBlogCommentsWithPaginationQueryVM request);
    Task<ApiResponseVM> CreateBlogComment(CreateBlogCommentCommandVM command);
    Task<ApiResponseVM> UpdateBlogComment(UpdateBlogCommentCommandVM command);
    Task<ApiResponseVM> RemoveBlogComment(RemoveBlogCommentCommandVM command);
}
