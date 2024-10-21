using Application.Models;
using MediatR;

namespace Application.Features.Section.Commands.CreateSection;

public class CreateSectionCommand: IRequest<ApiResponse>
{
    public string Name { get; set; } = string.Empty;
}
