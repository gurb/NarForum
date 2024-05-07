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

        [HttpGet("GetLikes")]
        public async Task<List<LikeDTO>> GetLikes()
        {
            var likes = await _mediator.Send(new GetLikesQuery());

            return likes;
        }


        [HttpGet("GetLikesByHeadingId")]
        public async Task<List<LikeDTO>> GetLikesByHeadingId(int headingId)
        {
            var likes = await _mediator.Send(
                new GetLikesQuery
                {
                    HeadingId = headingId
                }
            );

            return likes;
        }

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
