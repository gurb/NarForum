namespace AdminUI.Models.Post
{
    public class PostPaginationQueryVM
    {
        public Guid PostId { get; set; }
        public string? UserName { get; set; }
        public Guid HeadingId { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
