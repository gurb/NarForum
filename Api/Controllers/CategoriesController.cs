using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.RemoveCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Queries.GetCategories;
using Application.Features.Category.Queries.GetCategoriesWithPagination;
using Application.Features.Category.Queries.GetCategory;
using Application.Features.Category.Queries.GetParentCategories;
using Application.Models;
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

        [AllowAnonymous]
        [HttpGet("GetSectionCategories")]
        public async Task<List<CategoryDTO>> GetSectionCategories()
        {
            var query = new GetCategoriesQuery
            {
                IsOnlySection = true
            };

            var categories = await _mediator.Send(query);

            return categories;
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet("GetCategoryByIntId")]
        public async Task<CategoryDTO> Get(int Id)
        {
            var query = new GetCategoryQuery
            {
                CategoryId = Id
            };
            var category = await _mediator.Send(query);

            return category;
        }


        [AllowAnonymous]
        [HttpPost("GetCategoriesWithPagination")]
        public async Task<CategoriesPaginationDTO> GetCategoriesWithPagination(GetCategoriesWithPaginationQuery request)
        {
            var headings = await _mediator.Send(request);

            return headings;
        }

        [AllowAnonymous]
        [HttpGet("GetCategoriesById")]
        public async Task<List<CategoryDTO>> GetCategoriesById(Guid ParentCategoryId)
        {
            var query = new GetCategoriesQuery
            {
                ParentCategoryId = ParentCategoryId
            };

            var categories = await _mediator.Send(query);

            return categories;
        }


        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet("GetParentCategoriesByIntId")]
        public async Task<List<CategoryDTO>> GetParentCategoriesByIntId(int id)
        {
            var query = new GetParentCategoriesQuery
            {
                id = id
            };

            var categories = await _mediator.Send(query);

            return categories;
        }

        [HttpPost]
        public async Task<ApiResponse> Create(CreateCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("UpdateCategory")]
        public async Task<ApiResponse> Update(UpdateCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }


        [HttpPost("RemoveCategory")]
        public async Task<ActionResult> RemoveCategory(RemoveCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
