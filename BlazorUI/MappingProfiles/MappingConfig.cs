using AutoMapper;
using BlazorUI.Models;
using BlazorUI.Models.BlogCategory;
using BlazorUI.Models.BlogComment;
using BlazorUI.Models.BlogPost;
using BlazorUI.Models.Category;
using BlazorUI.Models.Favorite;
using BlazorUI.Models.Heading;
using BlazorUI.Models.Like;
using BlazorUI.Models.Message;
using BlazorUI.Models.Post;
using BlazorUI.Models.Section;
using BlazorUI.Models.StaticPage;
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

            CreateMap<HeadingDTO, HeadingVM>().ReverseMap();
            CreateMap<HeadingsPaginationDTO, HeadingsPaginationVM>().ReverseMap();
            CreateMap<CreateHeadingCommand, HeadingVM>().ReverseMap();

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
        }
    }
}
