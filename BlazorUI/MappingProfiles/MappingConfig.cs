using AutoMapper;
using BlazorUI.Models;
using BlazorUI.Models.BlogCategory;
using BlazorUI.Models.BlogComment;
using BlazorUI.Models.BlogPost;
using BlazorUI.Models.Category;
using BlazorUI.Models.Contact;
using BlazorUI.Models.Favorite;
using BlazorUI.Models.ForumSettings;
using BlazorUI.Models.Heading;
using BlazorUI.Models.Image;
using BlazorUI.Models.Like;
using BlazorUI.Models.Logo;
using BlazorUI.Models.Message;
using BlazorUI.Models.Post;
using BlazorUI.Models.Report;
using BlazorUI.Models.Section;
using BlazorUI.Models.StaticPage;
using BlazorUI.Models.TrackingLog;
using BlazorUI.Models.User;
using BlazorUI.Services.Base;

namespace BlazorUI.MappingProfiles
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<PostDTO, PostVM>().ReverseMap();
            CreateMap<PostsPaginationDTO, PostsPaginationVM>().ReverseMap();
            CreateMap<CreatePostCommand, PostVM>().ReverseMap();

            CreateMap<SectionDTO, SectionVM>().ReverseMap();
            CreateMap<CreateSectionCommand, SectionVM>().ReverseMap();
            CreateMap<UpdateSectionCommand, SectionVM>().ReverseMap();

            CreateMap<CategoryDTO, CategoryVM>().ReverseMap();
            CreateMap<CreateCategoryCommand, CategoryVM>().ReverseMap();
            CreateMap<UpdateCategoryCommandVM, UpdateCategoryCommand>().ReverseMap();

            CreateMap<HeadingDTO, HeadingVM>().ReverseMap();
            CreateMap<HeadingsPaginationDTO, HeadingsPaginationVM>().ReverseMap();
            CreateMap<CreateHeadingCommand, HeadingVM>().ReverseMap();
            CreateMap<GetHeadingsWithPaginationQuery, GetHeadingsWithPaginationQueryVM>().ReverseMap();
            CreateMap<PinHeadingCommand, PinHeadingCommandVM>().ReverseMap();
            CreateMap<LockHeadingCommand, LockHeadingCommandVM>().ReverseMap();

            CreateMap<UserInfoResponse, UserInfoVM>().ReverseMap();
            CreateMap<UsersPaginationDTO, UsersPaginationVM>().ReverseMap();

            CreateMap<LikeDTO, LikeVM>().ReverseMap();
            CreateMap<AddLikeCommand, LikeVM>().ReverseMap();

            CreateMap<FavoriteDTO, FavoriteVM>().ReverseMap();
            CreateMap<AddFavoriteCommand, FavoriteVM>().ReverseMap();

            CreateMap<ApiResponse, ApiResponseVM>().ReverseMap();

            CreateMap<AddMessageRequest, AddMessageRequestVM>().ReverseMap();
            CreateMap<CreateChatRequest, CreateChatRequestVM>().ReverseMap();
            CreateMap<ChangeChatStatusRequest, ChangeChatStatusRequestVM>().ReverseMap();
            CreateMap<ChatDTO, ChatVM>().ReverseMap();
            CreateMap<MessageDTO, MessageVM>().ReverseMap();
            CreateMap<GetMessageResponse, GetMessageResponseVM>().ReverseMap();
            CreateMap<GetChatResponse, GetChatResponseVM>().ReverseMap();
            CreateMap<UserDTO, UserVM>().ReverseMap();


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
            CreateMap<GetTrackingLogsQueryVM, GetTrackingLogsQueryVM>().ReverseMap();

            CreateMap<LogoDTO, LogoVM>().ReverseMap();

            CreateMap<ForumSettingsDTO, ForumSettingsVM>().ReverseMap();

            CreateMap<UploadImageRequest, UploadImageRequestVM>().ReverseMap();
            CreateMap<ImageBase64, ImageBase64VM>().ReverseMap();

            CreateMap<ChangeUserSettingsRequestVM, ChangeUserSettingsRequest>().ReverseMap();

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
        }
    }
}
