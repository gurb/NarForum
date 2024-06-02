using Application.Features.Heading.Commands.RemoveHeading;
using Application.Features.Post.Commands.CreatePost;
using Application.Features.Post.Commands.RemovePost;
using Application.Features.Post.Queries.GetAllPosts;
using Application.Features.Post.Queries.GetPostsWithPagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("GetPostsByHeadingId")]
        public async Task<List<PostDTO>> GetPostsByHeadingId(int HeadingId)
        {
            var query = new GetPostsQuery
            {
                HeadingId = HeadingId
            };

            var posts = await _mediator.Send(query);

            return posts;
        }

        [HttpPost("GetPostsWithPagination")]
        public async Task<PostsPaginationDTO> GetPostsWithPagination(GetPostsWithPaginationQuery request)
        {
            var posts = await _mediator.Send(request);

            return posts;
        }


        [HttpGet("GetPostsByHeadingIdWithPagination")]
        public async Task<PostsPaginationDTO> GetPostsByHeadingIdWithPagination(int HeadingId, int pageIndex, int pageSize)
        {
            var query = new GetPostsWithPaginationQuery
            {
                HeadingId = HeadingId,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var posts = await _mediator.Send(query);

            return posts;
        }

        [HttpGet("GetPostsByUserNameWithPagination")]
        public async Task<PostsPaginationDTO> GetPostsByUserNameWithPagination(string UserName, int pageIndex, int pageSize)
        {
            var query = new GetPostsWithPaginationQuery
            {
                UserName = UserName,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var posts = await _mediator.Send(query);

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

        [HttpPost("RemovePost")]
        public async Task<ActionResult> RemovePost(RemovePostCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
