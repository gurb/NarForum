using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Like.Commands.AddLike
{
    public class AddLikeCommandHandler : IRequestHandler<AddLikeCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly IUserService _userService;

        public AddLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository, IUserService userService)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _userService = userService;
        }

        public async Task<Guid> Handle(AddLikeCommand request, CancellationToken cancellationToken)
        {
            // validate incoming data
            //var validator = new CreatePostCommandValidator();
            //var validationResult = await validator.ValidateAsync(request, cancellationToken);

            //if (validationResult.Errors.Any())
            //{
            //    throw new BadRequestException("Invalid Post", validationResult);
            //}

            // convert to domain entity object

            var user = await _userService.GetCurrentUser();
            request.UserName = user.UserName;
            if (user.Id != null)
            {
                request.UserId = new Guid(user.Id);
            }

            try
            {
                var oldLike = await _likeRepository.GetAsync(x => x.HeadingId == request.HeadingId && x.UserName == request.UserName && x.PostId == request.PostId);

                if (oldLike != null)
                {
                    if(request.IsLike == oldLike.IsLike)
                    {
                        await _likeRepository.DeleteAsync(oldLike);
                    }
                    else
                    {
                        oldLike.IsLike = request.IsLike;
                        await _likeRepository.UpdateAsync(oldLike);
                    }

                    return oldLike.Id;
                }
                else
                {
                    var like = _mapper.Map<Domain.Like>(request);

                    await _likeRepository.AddAsync(like);

                    return like.Id;
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return Guid.Empty;

            // return record id
        }
    }
}
