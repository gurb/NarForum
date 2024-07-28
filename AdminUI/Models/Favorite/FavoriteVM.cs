namespace AdminUI.Models.Favorite
{
    public class FavoriteVM
    {
        public Guid Id { get; set; }
        public Guid HeadingId { get; set; }
        public Guid PostId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime? DateTime { get; set; }
    }
}
