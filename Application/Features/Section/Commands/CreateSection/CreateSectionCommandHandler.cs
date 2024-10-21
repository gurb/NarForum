using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Post.Commands.CreatePost;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Section.Commands.CreateSection;

public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly ISectionRepository _sectionRepository;

    public CreateSectionCommandHandler(IMapper mapper, ISectionRepository sectionRepository)
    {
        _mapper = mapper;
        _sectionRepository = sectionRepository;
    }

    public async Task<ApiResponse> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
    {
        ApiResponse response = new ApiResponse();

        try
        {
            // convert to domain entity object
            var section = _mapper.Map<Domain.Section>(request);

            // add to database
            await _sectionRepository.CreateAsync(section);
        }
        catch (Exception ex) 
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }

        return response;
    }
}
