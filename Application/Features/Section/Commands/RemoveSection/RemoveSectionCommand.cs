using MediatR;

namespace Application.Features.Section.Commands.RemoveSection
{
    public class RemoveSectionCommand : IRequest<int>
    {
        public int? SectionId { get; set; }
    }
}
