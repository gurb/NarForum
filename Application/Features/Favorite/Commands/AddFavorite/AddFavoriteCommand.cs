using MediatR;


namespace Application.Features.Favorite.Commands.AddFavorite
{
    public class AddFavoriteCommand : IRequest<Guid>
    {
        public Guid HeadingId { get; set; }
        public Guid PostId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}
