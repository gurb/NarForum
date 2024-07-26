using BlazorUI.Models;
using BlazorUI.Models.BlogComment;

namespace BlazorUI.Contracts;

public interface IBlogCommentService
{
    Task<List<BlogCommentVM>> GetBlogComments(GetBlogCommentsQueryVM request);
    Task<BlogCommentsPaginationVM> GetBlogCommentsWithPagination(GetBlogCommentsWithPaginationQueryVM request);
    Task<ApiResponseVM> CreateBlogComment(CreateBlogCommentCommandVM command);
    Task<ApiResponseVM> UpdateBlogComment(UpdateBlogCommentCommandVM command);
    Task<ApiResponseVM> RemoveBlogComment(RemoveBlogCommentCommandVM command);
}
