using Application.Features.Favorite.Commands.AddFavorite;
using Application.Features.Favorite.Queries.GetFavorites;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavoritesController : ControllerBase
    {

        private readonly IMediator _mediator;
        public FavoritesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetFavorites")]
        public async Task<List<FavoriteDTO>> GetFavorites()
        {
            var favorites = await _mediator.Send(new GetFavoritesQuery());
            return favorites;
        }

        [AllowAnonymous]
        [HttpGet("GetFavoritesByHeadingId")]
        public async Task<List<FavoriteDTO>> GetFavoritesByHeadingId(Guid headingId)
        {
            var favorites = await _mediator.Send(
                new GetFavoritesQuery
                {
                    HeadingId = headingId
                }
            );

            return favorites;
        }

        [AllowAnonymous]
        [HttpGet("GetFavoritesByUserName")]
        public async Task<List<FavoriteDTO>> GetFavoritesByUserName(string userName)
        {
            var favorites = await _mediator.Send(
                new GetFavoritesQuery
                {
                    UserName = userName
                }
            );

            return favorites;
        }


        [AllowAnonymous]
        [HttpGet("GetFavoritesByHeadingIdAndUserName")]
        public async Task<List<FavoriteDTO>> GetFavoritesByHeadingIdAndUserName(Guid headingId, string userName)
        {
            var favorites = await _mediator.Send(
                new GetFavoritesQuery
                {
                    HeadingId = headingId,
                    UserName = userName
                }
            );

            return favorites;
        }


        [HttpPost("AddFavorite")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddFavorite(AddFavoriteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
