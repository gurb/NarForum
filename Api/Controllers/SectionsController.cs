using Application.Features.Post.Commands.CreatePost;
using Application.Features.Post.Queries.GetAllPosts;
using Application.Features.Section.Commands.CreateSection;
using Application.Features.Section.Queries.GetSections;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            var posts = await _mediator.Send(new GetSectionsQuery());

            return posts;
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Create(CreateSectionCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
