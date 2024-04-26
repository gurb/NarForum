using Application.Features.Heading.Commands.CreateHeading;
using Application.Features.Heading.Queries;
using Application.Features.Heading.Queries.GetHeadings;
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
