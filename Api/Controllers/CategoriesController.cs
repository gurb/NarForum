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

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>The getting all categories result as the list of CategoryDTO</returns>
        [HttpGet]
        public async Task<List<CategoryDTO>> Get()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());

            return categories;
        }

        /// <summary>
        /// Gets all categories listed from section
        /// </summary>
        /// <returns>The getting all categories that listed from section result as the list of CategoryDTO</returns>
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

        /// <summary>
        /// Gets category by category name
        /// </summary>
        /// <param name="Name">Category Name(string)</param>
        /// <returns>The getting category result as CategoryDTO</returns>
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

        /// <summary>
        /// Gets category by integer category Id
        /// </summary>
        /// <param name="Id">Category Id(int)</param>
        /// <returns>The getting category result as CategoryDTO</returns>
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

        /// <summary>
        /// Gets category list with server-side pagination
        /// </summary>
        /// <param name="request">The request containing Name(string), PageIndex(int) and PageSize(int).</param>
        /// <returns>The getting the part of the list of categories and total size of the categories as CategoriesPaginationDTO.</returns>
        [AllowAnonymous]
        [HttpPost("GetCategoriesWithPagination")]
        public async Task<CategoriesPaginationDTO> GetCategoriesWithPagination(GetCategoriesWithPaginationQuery request)
        {
            var headings = await _mediator.Send(request);

            return headings;
        }

        /// <summary>
        /// Gets categories by parent category id
        /// </summary>
        /// <param name="ParentCategoryId">ParentCategoryId (Guid)</param>
        /// <returns>The getting the list of categories result as the list of CategoryDTO</returns>
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

        /// <summary>
        /// Gets categories by category name
        /// </summary>
        /// <param name="Name">Category Name(string)</param>
        /// <returns>The getting the list of categories result as the list of CategoryDTO</returns>
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

        /// <summary>
        /// Gets categories by parent category integer id
        /// </summary>
        /// <param name="id">Parent Category Integer Id</param>
        /// <returns>The getting the list of categories result as the list of CategoryDTO</returns>
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

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="command">The command containing Name(string), Description(string), SectionId(Guid), ParentCategoryId(Guid) fields.</param>
        /// <returns>The creating a new category result as ApiResponse.</returns>
        [HttpPost]
        public async Task<ApiResponse> Create(CreateCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Updates the selected category
        /// </summary>
        /// <param name="command">The command containing Id(Guid), Name(string), Description(string), OrderIndex(int) fields.</param>
        /// <returns>The updating the selected category result as ApiResponse</returns>
        [HttpPost("UpdateCategory")]
        public async Task<ApiResponse> Update(UpdateCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Removes the selected category
        /// </summary>
        /// <param name="command">The command containing Id(Guid) field.</param>
        /// <returns>The removing the selected category result as ApiResponse</returns>
        [HttpPost("RemoveCategory")]
        public async Task<ActionResult> RemoveCategory(RemoveCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
