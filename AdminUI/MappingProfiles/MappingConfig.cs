using AutoMapper;
using AdminUI.Models.Category;
using AdminUI.Models.Favorite;
using AdminUI.Models.Heading;
using AdminUI.Models.Like;
using AdminUI.Models.Post;
using AdminUI.Models.Section;
using AdminUI.Models.User;
using AdminUI.Services.Base;
using AdminUI.Models.Authorization.Permission;
using AdminUI.Models.Authorization.Role;
using AdminUI.Models;
using AdminUI.Models.Stat;
using AdminUI.Models.BlogCategory;
using AdminUI.Models.BlogComment;
using AdminUI.Models.BlogPost;
using AdminUI.Models.StaticPage;
using AdminUI.Models.TrackingLog;
using AdminUI.Models.Logo;
using AdminUI.Models.ForumSettings;
using AdminUI.Models.Image;


namespace AdminUI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<PostDTO, PostVM>().ReverseMap();
            CreateMap<PostsPaginationDTO, PostsPaginationVM>().ReverseMap();
            CreateMap<CreatePostCommand, PostVM>().ReverseMap();
            CreateMap<RemovePostCommand, RemovePostCommandVM>().ReverseMap();
            CreateMap<GetPostsWithPaginationQuery, PostPaginationQueryVM>().ReverseMap();

            CreateMap<SectionDTO, SectionVM>().ReverseMap();
            CreateMap<CreateSectionCommand, SectionVM>().ReverseMap();
            CreateMap<SectionsPaginationDTO, SectionPaginationVM>().ReverseMap();
            CreateMap<RemoveSectionCommand, RemoveSectionCommandVM>().ReverseMap();
            CreateMap<GetSectionsWithPaginationQuery, SectionPaginationQueryVM>().ReverseMap();

            CreateMap<CategoryDTO, CategoryVM>().ReverseMap();
            CreateMap<CreateCategoryCommand, CategoryVM>().ReverseMap();
            CreateMap<CategoriesPaginationDTO, CategoriesPaginationVM>().ReverseMap();
            CreateMap<GetCategoriesWithPaginationQuery, CategoriesPaginationQueryVM>().ReverseMap();
            CreateMap<RemoveCategoryCommand, RemoveCategoryCommandVM>().ReverseMap();

            CreateMap<HeadingDTO, HeadingVM>().ReverseMap();
            CreateMap<HeadingsPaginationDTO, HeadingsPaginationVM>().ReverseMap();
            CreateMap<CreateHeadingCommand, HeadingVM>().ReverseMap();
            CreateMap<GetHeadingsWithPaginationQuery, HeadingPaginationQueryVM>().ReverseMap();
            CreateMap<RemoveHeadingCommand, RemoveHeadingCommandVM>().ReverseMap();

            CreateMap<UserInfoResponse, UserInfoVM>().ReverseMap();
            CreateMap<GetUsersWithPaginationQuery, UsersPaginationQueryVM>().ReverseMap();
            CreateMap<UsersPaginationDTO, UsersPaginationVM>().ReverseMap();

            CreateMap<LikeDTO, LikeVM>().ReverseMap();
            CreateMap<AddLikeCommand, LikeVM>().ReverseMap();

            CreateMap<FavoriteDTO, FavoriteVM>().ReverseMap();
            CreateMap<AddFavoriteCommand, FavoriteVM>().ReverseMap();

            CreateMap<AddPermissionDefinitionRequest, AddPermissionDefinitionRequestVM>().ReverseMap();
            CreateMap<DeletePermissionDefinitionRequest, DeletePermissionDefinitionRequestVM>().ReverseMap();
            CreateMap<GetPermissionDefinitionsResponse, GetPermissionDefinitionsResponseVM>().ReverseMap();
            CreateMap<GetPermissionsResponse, GetPermissionsResponseVM>().ReverseMap();
            CreateMap<PermissionDefinitionDTO, PermissionDefinitionVM>().ReverseMap();
            CreateMap<PermissionDTO, PermissionVM>().ReverseMap();
            CreateMap<SetPermissionRequest, SetPermissionRequestVM>().ReverseMap();
            CreateMap<UpdatePermissionDefinitionRequest, UpdatePermissionDefinitionRequestVM>().ReverseMap();

            CreateMap<AddRoleRequest, AddRoleRequestVM>().ReverseMap();
            CreateMap<GetUserRolesResponse, GetUserRolesResponseVM>().ReverseMap();
            CreateMap<UpdateRoleRequest, UpdateRoleRequestVM>().ReverseMap();
            CreateMap<RemoveRoleRequest, RemoveRoleRequestVM>().ReverseMap();
            CreateMap<UserRoleResponse, UserRoleResponseVM>().ReverseMap();
            CreateMap<UserRoleResponse, RoleVM>().ReverseMap();

            CreateMap<ApiResponse, ApiResponseVM>().ReverseMap();

            CreateMap<AllStatsResponse, AllStatsResponseVM>().ReverseMap();
            CreateMap<StatsResponse, StatsResponseVM>().ReverseMap();
            CreateMap<StatWithDateDTO, StatWithDateVM>().ReverseMap();
            CreateMap<MonthStatDTO, MonthStatVM>().ReverseMap();

            CreateMap<BlogCategoryVM, BlogCategoryDTO>().ReverseMap();
            CreateMap<CreateBlogCategoryCommandVM, CreateBlogCategoryCommand>().ReverseMap();
            CreateMap<GetBlogCategoriesQueryVM, GetBlogCategoriesQuery>().ReverseMap();
            CreateMap<GetBlogCategoryQueryVM, GetBlogCategoryQuery>().ReverseMap();
            CreateMap<RemoveBlogCategoryCommandVM, RemoveBlogCategoryCommand>().ReverseMap();
            CreateMap<UpdateBlogCategoryCommandVM, UpdateBlogCategoryCommand>().ReverseMap();

            CreateMap<BlogCommentVM, BlogCommentDTO>().ReverseMap();
            CreateMap<BlogCommentsPaginationVM, BlogCommentsPaginationDTO>().ReverseMap();
            CreateMap<CreateBlogCommentCommandVM, CreateBlogCommentCommand>().ReverseMap();
            CreateMap<UpdateBlogCommentCommandVM, UpdateBlogCommentCommand>().ReverseMap();
            CreateMap<RemoveBlogCommentCommandVM, RemoveBlogCommentCommand>().ReverseMap();
            CreateMap<GetBlogCommentsQueryVM, GetBlogCommentsQuery>().ReverseMap();
            CreateMap<GetBlogCommentsWithPaginationQueryVM, GetBlogCommentsWithPaginationQuery>().ReverseMap();

            CreateMap<BlogPostVM, BlogPostDTO>().ReverseMap();
            CreateMap<BlogPostsPaginationVM, BlogPostsPaginationDTO>().ReverseMap();
            CreateMap<CreateBlogPostCommandVM, CreateBlogPostCommand>().ReverseMap();
            CreateMap<UpdateBlogPostCommandVM, UpdateBlogPostCommand>().ReverseMap();
            CreateMap<RemoveBlogPostCommandVM, RemoveBlogPostCommand>().ReverseMap();
            CreateMap<PublishBlogPostCommandVM, PublishBlogPostCommand>().ReverseMap();
            CreateMap<DraftBlogPostCommandVM, DraftBlogPostCommand>().ReverseMap();
            CreateMap<GetBlogPostQueryVM, GetBlogPostQuery>().ReverseMap();
            CreateMap<GetBlogPostsQueryVM, GetBlogPostsQuery>().ReverseMap();
            CreateMap<GetBlogPostsWithPaginationQueryVM, GetBlogPostsWithPaginationQuery>().ReverseMap();

            CreateMap<StaticPageVM, StaticPageDTO>().ReverseMap();
            CreateMap<StaticPagesPaginationVM, StaticPagesPaginationDTO>().ReverseMap();
            CreateMap<CreateStaticPageCommandVM, CreateStaticPageCommand>().ReverseMap();
            CreateMap<UpdateStaticPageCommandVM, UpdateStaticPageCommand>().ReverseMap();
            CreateMap<PublishStaticPageCommandVM, PublishStaticPageCommand>().ReverseMap();
            CreateMap<DraftStaticPageCommandVM, DraftStaticPageCommand>().ReverseMap();
            CreateMap<RemoveStaticPageCommandVM, RemoveStaticPageCommand>().ReverseMap();
            CreateMap<GetStaticPageQueryVM, GetStaticPageQuery>().ReverseMap();
            CreateMap<GetStaticPagesQueryVM, GetStaticPagesQuery>().ReverseMap();
            CreateMap<GetStaticPagesWithPaginationQueryVM, GetStaticPagesWithPaginationQuery>().ReverseMap();

            CreateMap<TrackingLogVM, TrackingLogDTO>().ReverseMap();
            CreateMap<AddTrackingLogCommandVM, AddTrackingLogCommand>().ReverseMap();
            CreateMap<GetTrackingLogQueryVM, GetTrackingLogQuery>().ReverseMap();
            CreateMap<GetTrackingLogsQueryVM, GetTrackingLogsQuery>().ReverseMap();
			CreateMap<TrackingLogsPaginationVM, TrackingLogsPaginationDTO>().ReverseMap();
			CreateMap<GetTrackingLogsWithPaginationQueryVM, GetTrackingLogsWithPaginationQuery>().ReverseMap();

            CreateMap<LogoDTO, LogoVM>().ReverseMap();
            CreateMap<AddLogoCommand, LogoVM>().ReverseMap();
            CreateMap<AddLogoCommand, AddLogoCommandVM>().ReverseMap();
            CreateMap<UpdateLogoCommand, UpdateLogoCommandVM>().ReverseMap();

            CreateMap<ForumSettingsDTO, ForumSettingsVM>().ReverseMap();
            CreateMap<UpdateForumSettingsCommand, UpdateForumSettingsCommandVM>().ReverseMap();

            CreateMap<UploadImageRequest, UploadImageRequestVM>().ReverseMap();

        }
    }
}
