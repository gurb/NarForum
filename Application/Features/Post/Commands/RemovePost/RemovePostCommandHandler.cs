using Application.Contracts.Persistence;
using Application.Features.Post.Commands.RemovePost;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.RemoveCategory
{

    public class RemovePostCommandHandler : IRequestHandler<RemovePostCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public RemovePostCommandHandler(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<Guid> Handle(RemovePostCommand request, CancellationToken cancellationToken)
        {
            if (request.PostId == Guid.Empty)
            {
                throw new NullReferenceException();
            }

            try
            {
                var post = await _postRepository.GetByIdAsyncWithTrack(request.PostId!);

                if (post != null)
                {
                    post.IsActive = !post.IsActive;
                    await _postRepository.UpdateAsync(post);
                    return post.Id;
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
