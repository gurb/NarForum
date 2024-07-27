using MediatR;


namespace Application.Features.Favorite.Commands.AddFavorite
{
    public class AddFavoriteCommand : IRequest<string>
    {
        public string? HeadingId { get; set; }
        public string? PostId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}
