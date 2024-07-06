using Application.Features.BlogCategory.Commands.CreateBlogCategory;
using Application.Features.BlogCategory.Queries.GetBlogCategories;
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

        [AllowAnonymous]
        [HttpGet("GetBlogCategories")]
        public async Task<List<BlogCategoryDTO>> GetBlogCategories()
        {
            var blogCategories = await _mediator.Send(new GetBlogCategoriesQuery());

            return blogCategories;
        }

        [HttpPost("AddBlogCategory")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ApiResponse> AddBlogCategory(CreateBlogCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
