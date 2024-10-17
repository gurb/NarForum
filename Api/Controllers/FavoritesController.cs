using Application.Features.Favorite.Commands.AddFavorite;
using Application.Features.Favorite.Queries.GetFavorites;
using Application.Features.Favorite.Queries.GetFavoritesWithPagination;
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

        /// <summary>
        /// Gets all favorites
        /// </summary>
        /// <returns>The getting all favorites result as the list of FavoriteDTO</returns>
        [HttpGet("GetFavorites")]
        public async Task<List<FavoriteDTO>> GetFavorites()
        {
            var favorites = await _mediator.Send(new GetFavoritesQuery());
            return favorites;
        }

        /// <summary>
        /// Gets favorites related giving HeadingId
        /// </summary>
        /// <param name="headingId">HeadingId(Guid)</param>
        /// <returns>The getting favorites result as the list of FavoriteDTO</returns>
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

        /// <summary>
        /// Gets favorites related giving username
        /// </summary>
        /// <param name="userName">UserName(string)</param>
        /// <returns>The getting favorites result as the list of FavoriteDTO</returns>
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

        /// <summary>
        /// Gets favorites related headingId and UserName
        /// </summary>
        /// <param name="headingId">HeadingId(Guid)</param>
        /// <param name="userName">Username(string)</param>
        /// <returns>The getting favorites result as the list of FavoriteDTO</returns>
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

        /// <summary>
        /// Gets favorites with server-side pagination.
        /// </summary>
        /// <param name="request">The request containing UserId(Guid), PageIndex(int) and PageSize(int).</param>
        /// <returns>The getting the part of the list of favorites and total size of the favorites as FavoritesPaginationDTO.</returns>
        [AllowAnonymous]
        [HttpPost("GetFavoritesWithPagination")]
        public async Task<FavoritesPaginationDTO> GetFavoritesWithPagination(GetFavoritesWithPaginationQuery request)
        {
            var favorites = await _mediator.Send(request);

            return favorites;
        }

        /// <summary>
        /// Adds favorite to selected post.
        /// </summary>
        /// <param name="command">The command containing HeadingId(Guid), PostId(Guid), UserId(Guid), UserName(string) and DateTime fields.</param>
        /// <returns>The adding favorite result as ActionResult</returns>
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
