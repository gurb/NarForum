using AutoMapper;
using BlazorUI.Models;
using BlazorUI.Models.Category;
using BlazorUI.Models.Favorite;
using BlazorUI.Models.Heading;
using BlazorUI.Models.Like;
using BlazorUI.Models.Post;
using BlazorUI.Models.Section;
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

            CreateMap<LikeDTO, LikeVM>().ReverseMap();
            CreateMap<AddLikeCommand, LikeVM>().ReverseMap();

            CreateMap<FavoriteDTO, FavoriteVM>().ReverseMap();
            CreateMap<AddFavoriteCommand, FavoriteVM>().ReverseMap();

            CreateMap<ApiResponse, ApiResponseVM>().ReverseMap();
        }
    }
}
