using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Favorite.Commands.AddFavorite
{
    
    public class AddFavoriteCommandHandler : IRequestHandler<AddFavoriteCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IUserService _userService;

        public AddFavoriteCommandHandler(IMapper mapper, IFavoriteRepository favoriteRepository, IUserService userService)
        {
            _mapper = mapper;
            _favoriteRepository = favoriteRepository;
            _userService = userService;
        }

        public async Task<string> Handle(AddFavoriteCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetCurrentUser();
            request.UserName = user.UserName;

            try
            {
                var oldFavorite = await _favoriteRepository.GetAsync(x => x.HeadingId == request.HeadingId && x.UserName == request.UserName && x.PostId == request.PostId);

                if (oldFavorite != null)
                {
                    await _favoriteRepository.DeleteAsync(oldFavorite);
                }
                else
                {
                    var favorite = _mapper.Map<Domain.Favorite>(request);

                    // add to database
                    await _favoriteRepository.AddAsync(favorite);
                    return favorite.Id;
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return string.Empty;
        }
    }
}
