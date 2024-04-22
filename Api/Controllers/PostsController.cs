using Application.Features.Post.Commands.CreatePost;
using Application.Features.Post.Queries.GetAllPosts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<PostDTO>> Get()
        {
            var posts = await _mediator.Send(new GetPostsQuery());

            return posts;
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Create(CreatePostCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
