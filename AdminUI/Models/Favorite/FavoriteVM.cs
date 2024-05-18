namespace AdminUI.Models.Favorite
{
    public class FavoriteVM
    {
        public int Id { get; set; }
        public int? HeadingId { get; set; }
        public int? PostId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime? DateTime { get; set; }
    }
}
