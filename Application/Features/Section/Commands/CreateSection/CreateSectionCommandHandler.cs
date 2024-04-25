using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Post.Commands.CreatePost;
using AutoMapper;
using MediatR;

namespace Application.Features.Section.Commands.CreateSection;

public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ISectionRepository _sectionRepository;

    public CreateSectionCommandHandler(IMapper mapper, ISectionRepository sectionRepository)
    {
        _mapper = mapper;
        _sectionRepository = sectionRepository;
    }

    public async Task<int> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
    {
        // validate incoming data
        //var validator = new CreatePostCommandValidator();
        //var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //if (validationResult.Errors.Any())
        //{
        //    throw new BadRequestException("Invalid Post", validationResult);
        //}

        // convert to domain entity object
        var section = _mapper.Map<Domain.Section>(request);

        // add to database
        await _sectionRepository.CreateAsync(section);

        // return record id
        return section.Id;
    }
}
