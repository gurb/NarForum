using Application.Features.Like.Commands.AddLike;
using Application.Features.Like.Queries.GetLikes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LikesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all likes.
        /// </summary>
        /// <returns>The getting all likes result as the list of LikeDTO</returns>
        [AllowAnonymous]
        [HttpGet("GetLikes")]
        public async Task<List<LikeDTO>> GetLikes()
        {
            var likes = await _mediator.Send(new GetLikesQuery());

            return likes;
        }

        /// <summary>
        /// Gets all likes by heading id.
        /// </summary>
        /// <param name="headingId">headingId(Guid)</param>
        /// <returns>The getting all likes result as the list of LikeDTO</returns>
        [AllowAnonymous]
        [HttpGet("GetLikesByHeadingId")]
        public async Task<List<LikeDTO>> GetLikesByHeadingId(Guid headingId)
        {
            var likes = await _mediator.Send(
                new GetLikesQuery
                {
                    HeadingId = headingId
                }
            );

            return likes;
        }

        /// <summary>
        /// Gets all likes by username
        /// </summary>
        /// <param name="userName">userName(string)</param>
        /// <returns>The getting all likes result as the list of LikeDTO</returns>
        [AllowAnonymous]
        [HttpGet("GetLikesByUserName")]
        public async Task<List<LikeDTO>> GetLikesByUserName(string userName)
        {
            var likes = await _mediator.Send(
                new GetLikesQuery
                {
                    UserName = userName
                }
            );

            return likes;
        }

        /// <summary>
        /// Adds like.
        /// </summary>
        /// <param name="command">The command containing UserName(string), UserId(Guid), PostId(Guid), HeadingId(Guid), IsLike(Bool) fields.</param>
        /// <returns>The adding like result as ActionResult.</returns>
        [HttpPost("AddLike")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddLike(AddLikeCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
