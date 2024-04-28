using Application.Features.Category.Queries.GetCategories;
using Application.Features.Heading.Commands.CreateHeading;
using Application.Features.Heading.Queries;
using Application.Features.Heading.Queries.GetHeading;
using Application.Features.Heading.Queries.GetHeadings;
using Application.Features.Heading.Queries.GetHeadingsWithPagination;
using Application.Features.Post.Queries.GetPostsWithPagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HeadingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HeadingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<HeadingDTO>> Get()
        {
            var headings = await _mediator.Send(new GetHeadingsQuery());

            return headings;
        }


        [HttpGet("GetHeadingById")]
        public async Task<HeadingDTO> GetHeadingById(int HeadingId)
        {
            var query = new GetHeadingQuery
            {
                HeadingId = HeadingId
            };

            var heading = await _mediator.Send(query);

            return heading;
        }

        [HttpGet("GetHeadingsByCategoryId")]
        public async Task<List<HeadingDTO>> GetHeadingsByCategoryId(int CategoryId)
        {
            var query = new GetHeadingsQuery
            {
                CategoryId = CategoryId
            };

            var headings = await _mediator.Send(query);

            return headings;
        }

        [HttpGet("GetHeadingsByCategoryName")]
        public async Task<List<HeadingDTO>> GetHeadingsByCategoryName(string CategoryName)
        {
            var query = new GetHeadingsQuery
            {
                CategoryName = CategoryName
            };

            var headings = await _mediator.Send(query);

            return headings;
        }

        [HttpGet("GetHeadingsByCategoryNameWithPagination")]
        public async Task<HeadingsPaginationDTO> GetHeadingsByCategoryNameWithPagination(string CategoryName, int pageIndex, int pageSize)
        {
            var query = new GetHeadingsWithPaginationQuery
            {
                CategoryName = CategoryName,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var posts = await _mediator.Send(query);

            return posts;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Create(CreateHeadingCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
