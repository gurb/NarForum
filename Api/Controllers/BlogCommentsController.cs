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

        [HttpPost]
        public async Task<List<BlogCommentDTO>> Get(GetBlogCommentsQuery request)
        {
            var blogPosts = await _mediator.Send(request);
            return blogPosts;
        }

        [AllowAnonymous]
        [HttpPost("GetBlogCommentsWithPagination")]
        public async Task<BlogCommentsPaginationDTO> GetBlogCommentsWithPagination(GetBlogCommentsWithPaginationQuery request)
        {
            var dto = await _mediator.Send(request);

            return dto;
        }

        [HttpPost("CreateBlogComment")]
        public async Task<ApiResponse> CreateBlogComment(CreateBlogCommentCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("UpdateBlogComment")]
        public async Task<ApiResponse> UpdateBlogComment(UpdateBlogCommentCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("RemoveBlogComment")]
        public async Task<ApiResponse> RemoveBlogComment(RemoveBlogCommentCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
