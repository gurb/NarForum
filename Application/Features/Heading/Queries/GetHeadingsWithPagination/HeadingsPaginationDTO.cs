namespace Application.Features.Heading.Queries.GetHeadingsWithPagination
{
    public class HeadingsPaginationDTO
    {
        public List<HeadingDTO>? Headings { get; set; }
        public int TotalCount { get; set; }
    }
}
