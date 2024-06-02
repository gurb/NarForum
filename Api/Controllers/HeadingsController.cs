using Application.Features.Heading.Commands.CreateHeading;
using Application.Features.Heading.Commands.RemoveHeading;
using Application.Features.Heading.Queries;
using Application.Features.Heading.Queries.GetHeading;
using Application.Features.Heading.Queries.GetHeadings;
using Application.Features.Heading.Queries.GetHeadingsWithPagination;
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

        [HttpPost("GetHeadingsWithPagination")]
        public async Task<HeadingsPaginationDTO> GetHeadingsWithPagination(GetHeadingsWithPaginationQuery request)
        {
            var headings = await _mediator.Send(request);

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

        [HttpGet("GetHeadingsByUserNameWithPagination")]
        public async Task<HeadingsPaginationDTO> GetHeadingsByUserNameWithPagination(string UserName, int pageIndex, int pageSize)
        {
            var query = new GetHeadingsWithPaginationQuery
            {
                UserName = UserName,
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

        [HttpPost("RemoveHeading")]
        public async Task<ActionResult> RemoveHeading(RemoveHeadingCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
