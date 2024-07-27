using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Section.Commands.UpdateSection;



public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly ISectionRepository _sectionRepository;

    public UpdateSectionCommandHandler(IMapper mapper, ISectionRepository sectionRepository)
    {
        _mapper = mapper;
        _sectionRepository = sectionRepository;
    }

    public async Task<ApiResponse> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
    {

        ApiResponse response = new ApiResponse();

        var section = await _sectionRepository.GetByIdAsync(request.Id!);

        if(section is not null)
        {
            section.Name = request.Name;

            await _sectionRepository.UpdateAsync(section);

            response.Message = "Section Updated";
        }
        else
        {
            response.IsSuccess = false;
            response.Message = "Not found";
        }


        return response;
    }
}
