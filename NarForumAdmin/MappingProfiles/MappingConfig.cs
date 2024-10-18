using AutoMapper;
using NarForumAdmin.Models.Category;
using NarForumAdmin.Models.Favorite;
using NarForumAdmin.Models.Heading;
using NarForumAdmin.Models.Like;
using NarForumAdmin.Models.Post;
using NarForumAdmin.Models.Section;
using NarForumAdmin.Models.User;
using NarForumAdmin.Services.Base;
using NarForumAdmin.Models.Authorization.Permission;
using NarForumAdmin.Models.Authorization.Role;
using NarForumAdmin.Models;
using NarForumAdmin.Models.Stat;
using NarForumAdmin.Models.BlogCategory;
using NarForumAdmin.Models.BlogComment;
using NarForumAdmin.Models.BlogPost;
using NarForumAdmin.Models.StaticPage;
using NarForumAdmin.Models.TrackingLog;
using NarForumAdmin.Models.Logo;
using NarForumAdmin.Models.ForumSettings;
using NarForumAdmin.Models.Image;
using NarForumAdmin.Models.Report;
using NarForumAdmin.Models.Contact;
using NarForumAdmin.Models.SmtpSettings;
using NarForumAdmin.Models.Enums;


namespace NarForumAdmin.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            try
            {
                CreateMap<PostDTO, PostVM>().ReverseMap();
                CreateMap<PostsPaginationDTO, PostsPaginationVM>().ReverseMap();
                CreateMap<CreatePostCommand, PostVM>().ReverseMap();
                CreateMap<RemovePostCommand, RemovePostCommandVM>().ReverseMap();
                CreateMap<GetPostsWithPaginationQuery, PostPaginationQueryVM>().ReverseMap();
                CreateMap<GetPostQuery, GetPostQueryVM>().ReverseMap();


                CreateMap<SectionDTO, SectionVM>().ReverseMap();
                CreateMap<CreateSectionCommand, SectionVM>().ReverseMap();
                CreateMap<SectionsPaginationDTO, SectionPaginationVM>().ReverseMap();
                CreateMap<RemoveSectionCommand, RemoveSectionCommandVM>().ReverseMap();
                CreateMap<GetSectionsWithPaginationQuery, SectionPaginationQueryVM>().ReverseMap();
                CreateMap<UpdateSectionCommand, SectionVM>().ReverseMap();


                CreateMap<CategoryDTO, CategoryVM>().ReverseMap();
                CreateMap<CreateCategoryCommand, CategoryVM>().ReverseMap();
                CreateMap<CategoriesPaginationDTO, CategoriesPaginationVM>().ReverseMap();
                CreateMap<GetCategoriesWithPaginationQuery, CategoriesPaginationQueryVM>().ReverseMap();
                CreateMap<RemoveCategoryCommand, RemoveCategoryCommandVM>().ReverseMap();
                CreateMap<UpdateCategoryCommand, UpdateCategoryCommandVM>().ReverseMap();

                CreateMap<HeadingDTO, HeadingVM>().ReverseMap();
                CreateMap<HeadingsPaginationDTO, HeadingsPaginationVM>().ReverseMap();
                CreateMap<CreateHeadingCommand, HeadingVM>().ReverseMap();
                CreateMap<GetHeadingsWithPaginationQuery, HeadingPaginationQueryVM>().ReverseMap();
                CreateMap<RemoveHeadingCommand, RemoveHeadingCommandVM>().ReverseMap();
                CreateMap<PinHeadingCommand, PinHeadingCommandVM>().ReverseMap();
                CreateMap<LockHeadingCommand, LockHeadingCommandVM>().ReverseMap();
                CreateMap<UpdateHeadingCommand, UpdateHeadingCommandVM>().ReverseMap();

                CreateMap<UserInfoResponse, UserInfoVM>().ReverseMap();
                CreateMap<GetUsersWithPaginationQuery, UsersPaginationQueryVM>().ReverseMap();
                CreateMap<UsersPaginationDTO, UsersPaginationVM>().ReverseMap();
                CreateMap<UpdateUserRequest, UpdateUserRequestVM>().ReverseMap();
                CreateMap<ResetPasswordRequest, ResetPasswordRequestVM>().ReverseMap();


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
                CreateMap<GetApiUserRoleRequest, GetApiUserRoleRequestVM>().ReverseMap();
                CreateMap<ApiUserRoleResponse, ApiUserRoleResponseVM>().ReverseMap();

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

                CreateMap<SmtpSettingsDTO, SmtpSettingsVM>().ReverseMap();
                CreateMap<UpdateSmtpSettingsCommand, UpdateSmtpSettingsCommandVM>().ReverseMap();

                CreateMap<UploadImageRequest, UploadImageRequestVM>().ReverseMap();
                CreateMap<ImageBase64, ImageBase64VM>().ReverseMap();

                CreateMap<ReportVM, ReportDTO>().ReverseMap();
                CreateMap<ReportsPaginationVM, ReportsPaginationDTO>().ReverseMap();
                CreateMap<CreateReportCommandVM, CreateReportCommand>().ReverseMap();
                CreateMap<RemoveReportCommandVM, RemoveReportCommand>().ReverseMap();
                CreateMap<GetReportQueryVM, GetReportQuery>().ReverseMap();
                CreateMap<GetReportsQueryVM, GetReportsQuery>().ReverseMap();
                CreateMap<GetReportsWithPaginationQueryVM, GetReportsWithPaginationQuery>().ReverseMap();

                CreateMap<ContactVM, ContactDTO>().ReverseMap();
                CreateMap<ContactsPaginationVM, ContactsPaginationDTO>().ReverseMap();
                CreateMap<CreateContactCommandVM, CreateContactCommand>().ReverseMap();
                CreateMap<RemoveContactCommandVM, RemoveContactCommand>().ReverseMap();
                CreateMap<GetContactQueryVM, GetContactQuery>().ReverseMap();
                CreateMap<GetContactsQueryVM, GetContactsQuery>().ReverseMap();
                CreateMap<GetContactsWithPaginationQueryVM, GetContactsWithPaginationQuery>().ReverseMap();

                CreateMap<ChatStatusVM, ChatStatus>().ReverseMap();
                CreateMap<ContactTypeVM, ContactType>().ReverseMap();
                CreateMap<SortTypeVM, SortType>().ReverseMap();
                CreateMap<Models.Enums.TrackingLogDateType, Services.Base.TrackingLogDateType>().ReverseMap();
                CreateMap<TrackingTypeVM, TrackingType>().ReverseMap();
                CreateMap<UploadImageTypeVM, UploadImageType>().ReverseMap();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
