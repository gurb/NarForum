using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Favorite.Commands.AddFavorite
{
    
    public class AddFavoriteCommandHandler : IRequestHandler<AddFavoriteCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteRepository _favoriteRepository;

        public AddFavoriteCommandHandler(IMapper mapper, IFavoriteRepository favoriteRepository)
        {
            _mapper = mapper;
            _favoriteRepository = favoriteRepository;
        }

        public async Task<int> Handle(AddFavoriteCommand request, CancellationToken cancellationToken)
        {
            // validate incoming data
            //var validator = new CreatePostCommandValidator();
            //var validationResult = await validator.ValidateAsync(request, cancellationToken);

            //if (validationResult.Errors.Any())
            //{
            //    throw new BadRequestException("Invalid Post", validationResult);
            //}

            // convert to domain entity object
            try
            {
                var favorite = _mapper.Map<Domain.Favorite>(request);

                // add to database
                await _favoriteRepository.AddAsync(favorite);

                return favorite.Id;

            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return 0;
        }
    }
}
