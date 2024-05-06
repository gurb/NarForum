using Application.Features.Favorite.Commands.AddFavorite;
using Application.Features.Favorite.Queries.GetFavorites;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class FavoriteProfile : Profile
    {
        public FavoriteProfile()
        {
            CreateMap<FavoriteDTO, Favorite>().ReverseMap();
            CreateMap<AddFavoriteCommand, Favorite>().ReverseMap();
        }
    }
}
