using MediatR;

namespace Application.Features.Section.Commands.CreateSection
{
    public class CreateSectionCommand: IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}
