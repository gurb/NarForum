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

        /// <summary>
        /// Gets all blog posts.
        /// </summary>
        /// <param name="request">The request containing BlogCategoryId(Guid) field.</param>
        /// <returns>The getting all blog posts result as the list of BlogPostDTO.</returns>
        [HttpPost]
        public async Task<List<BlogPostDTO>> Get(GetBlogPostsQuery request)
        {
            var blogPosts = await _mediator.Send(request);
            return blogPosts;
        }

        /// <summary>
        /// Gets the selected blog post
        /// </summary>
        /// <param name="request">The request containing IntId(int) and Id(Guid) fields.</param>
        /// <returns>The getting the selected blog post result as BlogPostDTO</returns>
        [AllowAnonymous]
        [HttpPost("GetBlogPost")]
        public async Task<BlogPostDTO> GetBlogPost(GetBlogPostQuery request)
        {
            var blogPost = await _mediator.Send(request);

            return blogPost;
        }

        /// <summary>
        /// Gets blog posts with server-side pagination
        /// </summary>
        /// <param name="request">The request containing BlogCategoryId(Guid), IsInclude(bool), SearchTitle(string), 
        /// Status(BlogPostStatus as enum)PageIndex(int) and PageSize(int).</param>
        /// <returns>The getting the part of the list of blog posts and total size of the blog posts as BlogPostsPaginationDTO.</returns>
        [AllowAnonymous]
        [HttpPost("GetBlogPostsWithPagination")]
        public async Task<BlogPostsPaginationDTO> GetBlogPostsWithPagination(GetBlogPostsWithPaginationQuery request)
        {
            var dto = await _mediator.Send(request);

            return dto;
        }

        /// <summary>
        /// Creates a new blog post
        /// </summary>
        /// <param name="command">The request containing Title(string), Content(string), Url(string)
        /// and BlogCategoryId(Guid) fields</param>
        /// <returns>The creating a new blog post result as ApiResponse</returns>
        [HttpPost("CreateBlogPost")]
        public async Task<ApiResponse> CreateBlogPost(CreateBlogPostCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Updates the selected blog post
        /// </summary>
        /// <param name="command">The request containing Title(string), Content(string), Url(string), 
        /// Id(Guid) as blog post id and BlogCategoryId(Guid) fields</param>
        /// <returns>The updating the selected blog post result as ApiResponse</returns>
        [HttpPost("UpdateBlogPost")]
        public async Task<ApiResponse> UpdateBlogPost(UpdateBlogPostCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Removes the selected blog post
        /// </summary>
        /// <param name="command">The request containing Id(Guid) fields</param>
        /// <returns>The removing the selected blog post result as ApiResponse</returns>
        [HttpPost("RemoveBlogPost")]
        public async Task<ApiResponse> RemoveBlogPost(RemoveBlogPostCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Publishes the selected blog post
        /// </summary>
        /// <param name="command">The request containing Id(Guid) fields</param>
        /// <returns>The publishing the selected blog post result as ApiResponse</returns>
        [HttpPost("PublishBlogPost")]
        public async Task<ApiResponse> PublishBlogPost(PublishBlogPostCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Drafts the selected blog post
        /// </summary>
        /// <param name="command">The request containing Id(Guid) fields</param>
        /// <returns>The drafting the selected blog post result as ApiResponse</returns>
        [HttpPost("DraftBlogPost")]
        public async Task<ApiResponse> DraftBlogPost(DraftBlogPostCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
