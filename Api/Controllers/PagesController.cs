using Application.Features.StaticPage.Commands.CreateStaticPage;
using Application.Features.StaticPage.Commands.RemoveStaticPage;
using Application.Features.StaticPage.Commands.UpdateStaticPage;
using Application.Features.StaticPage.Queries.GetStaticPage;
using Application.Features.StaticPage.Queries.GetStaticPages;
using Application.Features.StaticPage.Queries.GetStaticPagesWithPagination;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("GetStaticPages")]
        public async Task<List<StaticPageDTO>> GetStaticPages(GetStaticPagesQuery request)
        {
            var blogPosts = await _mediator.Send(request);
            return blogPosts;
        }

        [AllowAnonymous]
        [HttpPost("GetStaticPage")]
        public async Task<StaticPageDTO> GetStaticPage(GetStaticPageQuery request)
        {
            var staticPage = await _mediator.Send(request);
            return staticPage;
        }

        [HttpPost("GetStaticPagesWithPagination")]
        public async Task<StaticPagesPaginationDTO> GetBlogCommentsWithPagination(GetStaticPagesWithPaginationQuery request)
        {
            var dto = await _mediator.Send(request);

            return dto;
        }

        [HttpPost("CreateStaticPage")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ApiResponse> CreateStaticPage(CreateStaticPageCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("UpdateStaticPage")]
        public async Task<ApiResponse> UpdateStaticPage(UpdateStaticPageCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("RemoveStaticPage")]
        public async Task<ApiResponse> RemoveStaticPage(RemoveStaticPageCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
