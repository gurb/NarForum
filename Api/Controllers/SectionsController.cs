using Application.Features.Heading.Commands.RemoveHeading;
using Application.Features.Section.Commands.CreateSection;
using Application.Features.Section.Commands.RemoveSection;
using Application.Features.Section.Queries.GetSections;
using Application.Features.Section.Queries.GetSectionsWithPagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SectionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<SectionDTO>> Get()
        {
            var sections = await _mediator.Send(new GetSectionsQuery());

            return sections;
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Create(CreateSectionCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("GetSectionsWithPagination")]
        public async Task<SectionsPaginationDTO> GetSectionsWithPagination(GetSectionsWithPaginationQuery request)
        {
            var headings = await _mediator.Send(request);

            return headings;
        }


        [HttpPost("RemoveSection")]
        public async Task<ActionResult> RemoveSection(RemoveSectionCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
