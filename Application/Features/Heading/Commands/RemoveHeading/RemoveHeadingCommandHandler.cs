using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.Heading.Commands.RemoveHeading;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.RemoveCategory
{

    public class RemoveHeadingCommandHandler : IRequestHandler<RemoveHeadingCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IHeadingRepository _headingRepository;
        private readonly IPostRepository _postRepository;

        public RemoveHeadingCommandHandler(IMapper mapper, IHeadingRepository headingRepository, IPostRepository postRepository)
        {
            _mapper = mapper;
            _headingRepository = headingRepository;
            _postRepository = postRepository;
        }

        public async Task<Guid> Handle(RemoveHeadingCommand request, CancellationToken cancellationToken)
        {
            if (request.HeadingId == Guid.Empty)
            {
                throw new NullReferenceException();
            }

            try
            {
                var heading = await _headingRepository.GetByIdAsyncWithTrack(request.HeadingId!);

                if (heading != null)
                {
                    heading.IsActive = !heading.IsActive;
                    await _headingRepository.UpdateAsync(heading);
                    await UpdateHeadingIsActive(heading);
                    return heading.Id;
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return Guid.Empty;

            // return record id
        }

        private async Task UpdateHeadingIsActive(Domain.Heading heading)
        {
            var predicatePost = PredicateBuilder.True<Domain.Post>();

            predicatePost = predicatePost.And(x => x.HeadingId == heading.Id);

            var postsOfHeading = await _postRepository.GetAllAsync(predicatePost, true);
            foreach (var child in postsOfHeading)
            {
                child.IsActive = heading.IsActive;
            }
            _postRepository.UpdateList(postsOfHeading);
        }
    }
}
