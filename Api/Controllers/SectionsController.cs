using Application.Features.Heading.Commands.RemoveHeading;
using Application.Features.Section.Commands.CreateSection;
using Application.Features.Section.Commands.RemoveSection;
using Application.Features.Section.Commands.UpdateSection;
using Application.Features.Section.Queries.GetSections;
using Application.Features.Section.Queries.GetSectionsWithPagination;
using Application.Models;
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

        /// <summary>
        /// Gets all sections.
        /// </summary>
        /// <returns>The getting all sections result as the list of SectionDTO.</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<SectionDTO>> Get()
        {
            var sections = await _mediator.Send(new GetSectionsQuery());

            return sections;
        }

        /// <summary>
        /// Creates a new section.
        /// </summary>
        /// <param name="command">The command containing Name(string).</param>
        /// <returns>The creating a new section result as ActionResult.</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Create(CreateSectionCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }


        /// <summary>
        /// Gets sections with server-side pagination.
        /// </summary>
        /// <param name="request">The request containing PageIndex(int) and PageSize(int).</param>
        /// <returns>The getting the part of the list of sections and total size of the sections as SectionsPaginationDTO.</returns>
        [AllowAnonymous]
        [HttpPost("GetSectionsWithPagination")]
        public async Task<SectionsPaginationDTO> GetSectionsWithPagination(GetSectionsWithPaginationQuery request)
        {
            var headings = await _mediator.Send(request);

            return headings;
        }

        /// <summary>
        /// Updates the selected section.
        /// </summary>
        /// <param name="command">The request containing Id(Guid), OrderIndex(int) and Name(string) fields.</param>
        /// <returns>The updating the selected section result as ApiResponse.</returns>
        [HttpPost("UpdateSection")]
        public async Task<ApiResponse> UpdateSection(UpdateSectionCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Removes the selected section.
        /// </summary>
        /// <param name="command">The request containing Id(Guid).</param>
        /// <returns>The removing the selected section result as ActionResult.</returns>
        [HttpPost("RemoveSection")]
        public async Task<ActionResult> RemoveSection(RemoveSectionCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
