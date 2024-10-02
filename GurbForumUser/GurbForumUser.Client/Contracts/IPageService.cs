using GurbForumUser.Client.Models;
using GurbForumUser.Client.Models.StaticPage;

namespace GurbForumUser.Client.Contracts;

public interface IPageService
{
    Task<List<StaticPageVM>> GetStaticPages(GetStaticPagesQueryVM request);
    Task<StaticPageVM> GetStaticPage(GetStaticPageQueryVM request);
    Task<StaticPagesPaginationVM> GetStaticPagesWithPagination(GetStaticPagesWithPaginationQueryVM request);
    Task<ApiResponseVM> CreateStaticPage(CreateStaticPageCommandVM command);
    Task<ApiResponseVM> UpdateStaticPage(UpdateStaticPageCommandVM command);
    Task<ApiResponseVM> RemoveStaticPage(RemoveStaticPageCommandVM command);
    Task<ApiResponseVM> PublishStaticPage(PublishStaticPageCommandVM command);
    Task<ApiResponseVM> DraftStaticPage(DraftStaticPageCommandVM command);
}
