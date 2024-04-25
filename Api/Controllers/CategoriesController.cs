using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Queries.GetCategories;
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
