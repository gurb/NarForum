using Application.Features.BlogCategory.Commands.CreateBlogCategory;
using Application.Features.BlogCategory.Commands.RemoveBlogCategory;
using Application.Features.BlogCategory.Commands.UpdateBlogCategory;
using Application.Features.BlogCategory.Queries.GetBlogCategories;
using Application.Features.BlogCategory.Queries.GetBlogCategory;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all blog categories 
        /// </summary>
        /// <param name="query">The request containing SearchText(string) field.</param>
        /// <returns>The getting blog categories result as the list of BlogCategoryDTO</returns>
        [AllowAnonymous]
        [HttpPost("GetBlogCategories")]
        public async Task<List<BlogCategoryDTO>> GetBlogCategories(GetBlogCategoriesQuery query)
        {
            var blogCategories = await _mediator.Send(query);

            return blogCategories;
        }

        /// <summary>
        /// Gets the selected blog category
        /// </summary>
        /// <param name="query">The request containing Id(Guid) and Name(string) fields.</param>
        /// <returns>The getting blog category result as BlogCategoryDTO</returns>
        [AllowAnonymous]
        [HttpPost("GetBlogCategory")]
        public async Task<BlogCategoryDTO> GetBlogCategory(GetBlogCategoryQuery query)
        {
            var blogCategory = await _mediator.Send(query);

            return blogCategory;
        }

        /// <summary>
        /// Adds a new blog category.
        /// </summary>
        /// <param name="command">The request containing Name(string) field.</param>
        /// <returns>The adding a new blog category result as ApiResponse</returns>
        [HttpPost("AddBlogCategory")]
        public async Task<ApiResponse> AddBlogCategory(CreateBlogCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Updates the blog category
        /// </summary>
        /// <param name="command">The request containing Id(Guid) and Name(string) fields.</param>
        /// <returns>The updating the blog category result as ApiResponse</returns>
        [HttpPost("UpdateBlogCategory")]
        public async Task<ApiResponse> UpdateBlogCategory(UpdateBlogCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Removes the blog category
        /// </summary>
        /// <param name="command">he request containing Id(Guid) field</param>
        /// <returns>The removing the blog catetory result as ApiResponse</returns>
        [HttpPost("RemoveBlogCategory")]
        public async Task<ApiResponse> RemoveBlogCategory(RemoveBlogCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

    }
}
