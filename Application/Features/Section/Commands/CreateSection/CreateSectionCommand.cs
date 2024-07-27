using MediatR;

namespace Application.Features.Section.Commands.CreateSection;

public class CreateSectionCommand: IRequest<string>
{
    public string Name { get; set; } = string.Empty;
}
