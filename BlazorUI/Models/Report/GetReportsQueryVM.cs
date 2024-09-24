namespace BlazorUI.Models.Report
{
    public class GetReportsQueryVM
    {
        public string? Title { get; set; }
        public string? Message { get; set; }
        public Guid? SenderUserId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? HeadingId { get; set; }
    }
}
