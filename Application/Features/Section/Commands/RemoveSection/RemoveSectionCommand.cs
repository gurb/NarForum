using MediatR;

namespace Application.Features.Section.Commands.RemoveSection
{
    public class RemoveSectionCommand : IRequest<Guid>
    {
        public Guid SectionId { get; set; }
    }
}
