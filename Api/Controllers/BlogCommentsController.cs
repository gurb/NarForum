using Application.Features.BlogComment.Commands.CreateBlogComment;
using Application.Features.BlogComment.Commands.RemoveBlogComment;
using Application.Features.BlogComment.Commands.UpdateBlogComment;
using Application.Features.BlogComment.Queries.GetBlogComments;
using Application.Features.BlogComment.Queries.GetBlogCommentsWithPagination;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCommentsController : ControllerBase
    {

        private readonly IMediator _mediator;
        public BlogCommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all blog comments.
        /// </summary>
        /// <param name="request">The request containing BlogPostId(Guid) field.</param>
        /// <returns>The getting all blog comments result as the list of BlogCommentDTO</returns>
        [HttpPost]
        public async Task<List<BlogCommentDTO>> Get(GetBlogCommentsQuery request)
        {
            var blogPosts = await _mediator.Send(request);
            return blogPosts;
        }

        /// <summary>
        /// Gets the blog comments with server-side pagination.
        /// </summary>
        /// <param name="request">The request containing BlogPostId(Guid), PageIndex(int) and PageSize(int) fields.</param>
        /// <returns>The getting the part of the list of blog comments and total size of the blog comments.</returns>
        [AllowAnonymous]
        [HttpPost("GetBlogCommentsWithPagination")]
        public async Task<BlogCommentsPaginationDTO> GetBlogCommentsWithPagination(GetBlogCommentsWithPaginationQuery request)
        {
            var dto = await _mediator.Send(request);

            return dto;
        }

        /// <summary>
        /// Creates a new blog comment for related the blog post.
        /// </summary>
        /// <param name="command">The request containing BlogPostId(Guid) and Content(string) fields.</param>
        /// <returns>The creating a new blog comment result as ApiResponse.</returns>
        [HttpPost("CreateBlogComment")]
        public async Task<ApiResponse> CreateBlogComment(CreateBlogCommentCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Updates the blog comment.
        /// </summary>
        /// <param name="command">The request containing Id(Guid) as blog comment id and Content(string) fields.</param>
        /// <returns>The updating the selected blog comment result as ApiResponse.</returns>
        [HttpPost("UpdateBlogComment")]
        public async Task<ApiResponse> UpdateBlogComment(UpdateBlogCommentCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Removes the blogg comment
        /// </summary>
        /// <param name="command">The request containing Id as blog comment id field.</param>
        /// <returns>The removing the selected blog comment result as ApiResponse.</returns>
        [HttpPost("RemoveBlogComment")]
        public async Task<ApiResponse> RemoveBlogComment(RemoveBlogCommentCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
