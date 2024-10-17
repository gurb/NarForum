namespace NarForumUser.Client.Models.Favorite
{
    public class FavoritesPaginationVM
    {
        public List<FavoriteVM>? Favorites { get; set; }
        public int TotalCount { get; set; }
    }
}
