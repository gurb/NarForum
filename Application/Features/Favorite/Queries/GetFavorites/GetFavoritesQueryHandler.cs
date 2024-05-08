using Application.Contracts.Persistence;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Favorite.Queries.GetFavorites
{

    public class GetFavoritesQueryHandler : IRequestHandler<GetFavoritesQuery, List<FavoriteDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteRepository _favoriteRepository;

        public GetFavoritesQueryHandler(IMapper mapper, IFavoriteRepository favoriteRepository)
        {
            _mapper = mapper;
            _favoriteRepository = favoriteRepository;
        }

        public async Task<List<FavoriteDTO>> Handle(GetFavoritesQuery request, CancellationToken cancellationToken)
        {
            // query the database
            var favorites = new List<Domain.Favorite>();

            if(request.HeadingId != null && request.UserName != null)
            {
                favorites = await _favoriteRepository.GetAllAsync(x => x.HeadingId == request.HeadingId && x.UserName == request.UserName);
            }
            else if(request.HeadingId != null)
            {
                favorites = await _favoriteRepository.GetAllAsync(x => x.HeadingId == request.HeadingId);
            }
            else if (request.PostId != null)
            {
                favorites = await _favoriteRepository.GetAllAsync(x => x.PostId == request.PostId);
            }
            else if (request.UserName != null)
            {
                favorites = await _favoriteRepository.GetAllAsync(x => x.UserName == request.UserName);
            }

            // convert data objecs to DTOs
            var data = _mapper.Map<List<FavoriteDTO>>(favorites);

            // return list of DTOs
            return data;
        }
    }
}
