namespace GurbForumUser.Client.Models.Report
{
    public class GetReportsWithPaginationQueryVM
    {
        public string? Title { get; set; }
        public string? Message { get; set; }
        public Guid? SenderUserId { get; set; }
        public Guid? PostId { get; set; }
        public Guid? HeadingId { get; set; }

        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
