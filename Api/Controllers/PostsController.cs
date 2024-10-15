using Application.Features.Heading.Commands.RemoveHeading;
using Application.Features.Post.Commands.CreatePost;
using Application.Features.Post.Commands.RemovePost;
using Application.Features.Post.Queries.GetAllPosts;
using Application.Features.Post.Queries.GetPostsWithPagination;
using Application.Models;
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

        /// <summary>
        /// Gets all posts.
        /// </summary>
        /// <returns>The getting all posts result as the list of PostDTO.</returns>
        [HttpGet]
        public async Task<List<PostDTO>> Get()
        {
            var posts = await _mediator.Send(new GetPostsQuery());

            return posts;
        }

        /// <summary>
        /// Gets posts by heading id.
        /// </summary>
        /// <param name="HeadingId">HeadingId(Guid)</param>
        /// <returns>The getting posts result as the list of PostDTO.</returns>
        [AllowAnonymous]
        [HttpGet("GetPostsByHeadingId")]
        public async Task<List<PostDTO>> GetPostsByHeadingId(Guid HeadingId)
        {
            var query = new GetPostsQuery
            {
                HeadingId = HeadingId
            };

            var posts = await _mediator.Send(query);

            return posts;
        }

        /// <summary>
        /// Gets posts with server-side pagination.
        /// </summary>
        /// <param name="request">The request containing PostId(Guid), UserName(string), IsWithHeading(bool), 
        /// HeadingId(Guid), SearchUsername(string), SearchContent(string), IsAdminPanel(bool), SortType(SortType as enum), PageIndex(int) and PageSize(int).</param>
        /// <returns>The getting the part of the list of posts and total size of the posts as PostsPaginationDTO.</returns>
        [AllowAnonymous]
        [HttpPost("GetPostsWithPagination")]
        public async Task<PostsPaginationDTO> GetPostsWithPagination(GetPostsWithPaginationQuery request)
        {
            var posts = await _mediator.Send(request);

            return posts;
        }

        /// <summary>
        /// Gets posts with server-side pagination by headingId.
        /// </summary>
        /// <param name="HeadingId">HeadingId(Guid)</param>
        /// <param name="pageIndex">pageIndex(int)</param>
        /// <param name="pageSize">pageSize(int)</param>
        /// <returns>The getting the part of the list of posts and total size of the posts as PostsPaginationDTO.</returns>
        [AllowAnonymous]
        [HttpGet("GetPostsByHeadingIdWithPagination")]
        public async Task<PostsPaginationDTO> GetPostsByHeadingIdWithPagination(Guid HeadingId, int pageIndex, int pageSize)
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

        /// <summary>
        /// Gets posts with server-side pagination by username.
        /// </summary>
        /// <param name="UserName">UserName(string)</param>
        /// <param name="pageIndex">pageIndex(int)</param>
        /// <param name="pageSize">pageSize(int)</param>
        /// <returns>The getting the part of the list of posts and total size of the posts as PostsPaginationDTO.</returns>
        [AllowAnonymous]
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

        /// <summary>
        /// Creates a new post.
        /// </summary>
        /// <param name="command">The command containing Content(string), HeadingId(Guid), QuotePostIds(Guid list)</param>
        /// <returns>The creating a new post result as ApiResponse</returns>
        [HttpPost]
        public async Task<ApiResponse> Create(CreatePostCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Removes the selected post.
        /// </summary>
        /// <param name="command">The command containing PostId(Guid)</param>
        /// <returns>The removing the selected post result as ApiResponse</returns>
        [HttpPost("RemovePost")]
        public async Task<ActionResult> RemovePost(RemovePostCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
