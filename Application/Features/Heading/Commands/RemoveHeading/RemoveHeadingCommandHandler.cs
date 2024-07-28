using Application.Contracts.Persistence;
using Application.Features.Heading.Commands.RemoveHeading;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.RemoveCategory
{

    public class RemoveHeadingCommandHandler : IRequestHandler<RemoveHeadingCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IHeadingRepository _headingRepository;

        public RemoveHeadingCommandHandler(IMapper mapper, IHeadingRepository headingRepository)
        {
            _mapper = mapper;
            _headingRepository = headingRepository;
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
    }
}
