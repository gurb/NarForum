using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Like.Commands.AddLike
{


    public class AddLikeCommandHandler : IRequestHandler<AddLikeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;

        public AddLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
        }

        public async Task<int> Handle(AddLikeCommand request, CancellationToken cancellationToken)
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
                var like = _mapper.Map<Domain.Like>(request);

                // add to database
                await _likeRepository.AddAsync(like);

                return like.Id;

            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return 0;

            // return record id
        }
    }
}
