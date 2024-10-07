namespace NarForumUser.Client.Models.Report
{
    public class CreateReportCommandVM
    {
        public string? Title { get; set; }
        public string? Message { get; set; }
        public Guid? PostId { get; set; }
        public Guid? HeadingId { get; set; }
        public int HeadingIndex { get; set; }
    }
}
