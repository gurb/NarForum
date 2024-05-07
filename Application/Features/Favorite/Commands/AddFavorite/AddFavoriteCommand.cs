using MediatR;


namespace Application.Features.Favorite.Commands.AddFavorite
{
    public class AddFavoriteCommand : IRequest<int>
    {
        public int? HeadingId { get; set; }
        public int? PostId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}
