using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.Favorite.Queries.GetFavorites;
using Application.Features.Heading.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Favorite.Queries.GetFavoritesWithPagination
{
    public class GetFavoritesWithPaginationQueryHandler : IRequestHandler<GetFavoritesWithPaginationQuery, FavoritesPaginationDTO>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IHeadingRepository _headingRepository;
        private readonly IUserService _userService;

        public GetFavoritesWithPaginationQueryHandler(IMapper mapper, IFavoriteRepository favoriteRepository, IHeadingRepository headingRepository, IUserService userService)
        {
            _mapper = mapper;
            _favoriteRepository = favoriteRepository;
            _headingRepository = headingRepository;
            _userService = userService;
        }

        public async Task<FavoritesPaginationDTO> Handle(GetFavoritesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Favorite> favorites;
            // query the database

            var predicate = PredicateBuilder.True<Domain.Favorite>();

            if(request.UserId is not null)
            {
                predicate = predicate.And(x => x.UserId == request.UserId);
            }
            if (request.UserName is not null)
            {
                predicate = predicate.And(x => x.UserName == request.UserName);
            }

            favorites = await _favoriteRepository.GetFavoritesWithPagination(predicate, request.PageIndex!.Value, request.PageSize!.Value);

            var data = _mapper.Map<List<FavoriteDTO>>(favorites);
            
            if(favorites is not null && favorites.Count > 0)
            {
                List<Guid> headingIds = favorites.Select(x => x.HeadingId).Distinct().ToList();

                var predicateHeading = PredicateBuilder.True<Domain.Heading>();

                List<Domain.Heading> headings = await _headingRepository.GetHeadingsByIds(headingIds);

                if(headings is not null && headings.Count() > 0)
                {
                    foreach (var item in data)
                    {
                        var heading = headings.FirstOrDefault(x => x.Id == item.HeadingId);

                        if (heading is not null) 
                        {
                            item.Heading = _mapper.Map<HeadingDTO>(heading);
                        }
                    }
                }
            }

            FavoritesPaginationDTO dto = new FavoritesPaginationDTO
            {
                Favorites = data,
                TotalCount = _favoriteRepository.GetCount(predicate)
            };
            return dto;
        }
    }
}
