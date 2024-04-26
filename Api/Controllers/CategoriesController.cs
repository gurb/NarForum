using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Queries.GetCategories;
using Application.Features.Category.Queries.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CategoryDTO>> Get()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());

            return categories;
        }

        [HttpGet("GetCategoryByName")]
        public async Task<CategoryDTO> Get(string Name)
        {
            var query = new GetCategoryQuery
            {
                CategoryName = Name
            };
            var category = await _mediator.Send(query);

            return category;
        }

        [HttpGet("GetCategoriesById")]
        public async Task<List<CategoryDTO>> GetCategoriesById(int ParentCategoryId)
        {
            var query = new GetCategoriesQuery
            {
                ParentCategoryId = ParentCategoryId
            };

            var categories = await _mediator.Send(query);

            return categories;
        }

        [HttpGet("GetCategoriesByName")]
        public async Task<List<CategoryDTO>> GetCategoriesByName(string Name)
        {
            var query = new GetCategoriesQuery
            {
                CategoryName = Name
            };

            var categories = await _mediator.Send(query);

            return categories;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Create(CreateCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
