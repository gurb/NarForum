using AutoMapper;
using AdminUI.Models.Category;
using AdminUI.Models.Favorite;
using AdminUI.Models.Heading;
using AdminUI.Models.Like;
using AdminUI.Models.Post;
using AdminUI.Models.Section;
using AdminUI.Models.User;
using AdminUI.Services.Base;

namespace AdminUI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<PostDTO, PostVM>().ReverseMap();
            CreateMap<PostsPaginationDTO, PostsPaginationVM>().ReverseMap();
            CreateMap<CreatePostCommand, PostVM>().ReverseMap();
            CreateMap<GetPostsWithPaginationQuery, PostPaginationQueryVM>().ReverseMap();

            CreateMap<SectionDTO, SectionVM>().ReverseMap();
            CreateMap<CreateSectionCommand, SectionVM>().ReverseMap();
            CreateMap<SectionsPaginationDTO, SectionPaginationVM>().ReverseMap();
            CreateMap<GetSectionsWithPaginationQuery, SectionPaginationQueryVM>().ReverseMap();

            CreateMap<CategoryDTO, CategoryVM>().ReverseMap();
            CreateMap<CreateCategoryCommand, CategoryVM>().ReverseMap();
            CreateMap<CategoriesPaginationDTO, CategoriesPaginationVM>().ReverseMap();
            CreateMap<GetCategoriesWithPaginationQuery, CategoriesPaginationQueryVM>().ReverseMap();

            CreateMap<HeadingDTO, HeadingVM>().ReverseMap();
            CreateMap<HeadingsPaginationDTO, HeadingsPaginationVM>().ReverseMap();
            CreateMap<CreateHeadingCommand, HeadingVM>().ReverseMap();
            CreateMap<GetHeadingsWithPaginationQuery, HeadingPaginationQueryVM>().ReverseMap();

            CreateMap<UserInfoResponse, UserInfoVM>().ReverseMap();

            CreateMap<LikeDTO, LikeVM>().ReverseMap();
            CreateMap<AddLikeCommand, LikeVM>().ReverseMap();

            CreateMap<FavoriteDTO, FavoriteVM>().ReverseMap();
            CreateMap<AddFavoriteCommand, FavoriteVM>().ReverseMap();
        }
    }
}
