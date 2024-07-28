namespace BlazorUI.Models.Favorite
{
    public class FavoriteVM
    {
        public string? Id { get; set; }
        public string? HeadingId { get; set; }
        public string? PostId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime? DateTime { get; set; }
    }
}
