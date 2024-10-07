namespace NarForumAdmin.Models.StaticPage
{
    public class GetStaticPagesWithPaginationQueryVM
    {
        public string? Title { get; set; }
        public string? SearchTitle { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
