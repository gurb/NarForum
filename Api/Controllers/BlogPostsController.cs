using Application.Features.BlogPost.Commands.CreateBlogPost;
using Application.Features.BlogPost.Commands.DraftBlogPost;
using Application.Features.BlogPost.Commands.PublishBlogPost;
using Application.Features.BlogPost.Commands.RemoveBlogPost;
using Application.Features.BlogPost.Commands.UpdateBlogPost;
using Application.Features.BlogPost.Queries.GetBlogPost;
using Application.Features.BlogPost.Queries.GetBlogPosts;
using Application.Features.BlogPost.Queries.GetBlogPostsWithPagination;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {

        private readonly IMediator _mediator;
        public BlogPostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<List<BlogPostDTO>> Get(GetBlogPostsQuery request)
        {
            var blogPosts = await _mediator.Send(request);
            return blogPosts;
        }

        [AllowAnonymous]
        [HttpPost("GetBlogPost")]
        public async Task<BlogPostDTO> GetBlogPost(GetBlogPostQuery request)
        {
            var blogPost = await _mediator.Send(request);

            return blogPost;
        }

        [AllowAnonymous]
        [HttpPost("GetBlogPostsWithPagination")]
        public async Task<BlogPostsPaginationDTO> GetBlogPostsWithPagination(GetBlogPostsWithPaginationQuery request)
        {
            var dto = await _mediator.Send(request);

            return dto;
        }

        [HttpPost("CreateBlogPost")]
        public async Task<ApiResponse> CreateBlogPost(CreateBlogPostCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("UpdateBlogPost")]
        public async Task<ApiResponse> UpdateBlogPost(UpdateBlogPostCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("RemoveBlogPost")]
        public async Task<ApiResponse> RemoveBlogPost(RemoveBlogPostCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("PublishBlogPost")]
        public async Task<ApiResponse> PublishBlogPost(PublishBlogPostCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("DraftBlogPost")]
        public async Task<ApiResponse> DraftBlogPost(DraftBlogPostCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
