namespace NarForumUser.Client.Models.Favorite
{
    public class GetFavoritesWithPaginationQueryVM
    {
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
