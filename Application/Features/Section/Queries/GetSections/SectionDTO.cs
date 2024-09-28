namespace Application.Features.Section.Queries.GetSections;

public class SectionDTO
{
    public Guid Id { get; set; } = Guid.Empty;
	public string Name { get; set; } = string.Empty;
    public int OrderIndex { get; set; }
}