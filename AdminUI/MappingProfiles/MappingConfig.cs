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
        }
    }
}
