using MediatR;

namespace Application.Features.Section.Commands.RemoveSection
{
    public class RemoveSectionCommand : IRequest<string>
    {
        public string? SectionId { get; set; }
    }
}
