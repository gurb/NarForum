using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Heading.Commands.CreateHeading
{
    public class CreateHeadingCommandHandler : IRequestHandler<CreateHeadingCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IHeadingRepository _HeadingRepository;
        private readonly IPostRepository _PostRepository;

        public CreateHeadingCommandHandler(IMapper mapper, IHeadingRepository HeadingRepository, IPostRepository PostRepository)
        {
            _mapper = mapper;
            _HeadingRepository = HeadingRepository;
            _PostRepository = PostRepository;
        }

        public async Task<int> Handle(CreateHeadingCommand request, CancellationToken cancellationToken)
        {
            // validate incoming data
            //var validator = new CreatePostCommandValidator();
            //var validationResult = await validator.ValidateAsync(request, cancellationToken);

            //if (validationResult.Errors.Any())
            //{
            //    throw new BadRequestException("Invalid Post", validationResult);
            //}

            // convert to domain entity object
            var Heading = _mapper.Map<Domain.Heading>(request);


            // add to database
            await _HeadingRepository.CreateAsync(Heading);

            if (request.Content != null)
            {
                Domain.Post headingPost = new Domain.Post
                {
                    HeadingId = Heading.Id,
                    Content = request.Content,
                };

                await _PostRepository.CreateAsync(headingPost);
            }

            // return record id
            return Heading.Id;
        }
    }
}
