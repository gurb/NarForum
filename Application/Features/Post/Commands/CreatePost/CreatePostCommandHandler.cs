using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            // validate incoming data
            var validator = new CreatePostCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if(validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Post", validationResult);
            }

            // convert to domain entity object
            var post = _mapper.Map<Domain.Post>(request);

            // add to database
            await _postRepository.CreateAsync(post);

            // return record id
            return post.Id;
        }
    }
}
