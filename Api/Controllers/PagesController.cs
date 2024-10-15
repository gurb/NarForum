using Application.Features.StaticPage.Commands.CreateStaticPage;
using Application.Features.StaticPage.Commands.DraftStaticPage;
using Application.Features.StaticPage.Commands.PublishStaticPage;
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

        /// <summary>
        /// Gets all static pages.
        /// </summary>
        /// <param name="request">The request containing no fields currently.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("GetStaticPages")]
        public async Task<List<StaticPageDTO>> GetStaticPages(GetStaticPagesQuery request)
        {
            var blogPosts = await _mediator.Send(request);
            return blogPosts;
        }

        /// <summary>
        /// Gets the selected static page.
        /// </summary>
        /// <param name="request">Id(Guid)</param>
        /// <returns>The getting the selected static page result as StaticPageDTO.</returns>
        [AllowAnonymous]
        [HttpPost("GetStaticPage")]
        public async Task<StaticPageDTO> GetStaticPage(GetStaticPageQuery request)
        {
            var staticPage = await _mediator.Send(request);
            return staticPage;
        }

        /// <summary>
        /// Gets static pages with server-side pagination.
        /// </summary>
        /// <param name="request">The request containing SearchTitle(string), 
        /// PageIndex(int) and PageSize(int).</param>
        /// <returns>The getting the part of the list of static pages and total size of the static pages as StaticPagesPaginationDTO.</returns>
        [HttpPost("GetStaticPagesWithPagination")]
        public async Task<StaticPagesPaginationDTO> GetStaticPagesWithPagination(GetStaticPagesWithPaginationQuery request)
        {
            var dto = await _mediator.Send(request);

            return dto;
        }

        /// <summary>
        /// Creates a new static page
        /// </summary>
        /// <param name="command">The command containing Title(string), Url(string), Content(string), Author(string)</param>
        /// <returns>The creating a new static page result as ApiResponse</returns>
        [HttpPost("CreateStaticPage")]
        public async Task<ApiResponse> CreateStaticPage(CreateStaticPageCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Updates the selected static page
        /// </summary>
        /// <param name="command">The command containing Id(Guid), Title(string), Url(string), Content(string), Author(string)</param>
        /// <returns>The updating the selected static page result as ApiResponse</returns>
        [HttpPost("UpdateStaticPage")]
        public async Task<ApiResponse> UpdateStaticPage(UpdateStaticPageCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Removes the selected static page
        /// </summary>
        /// <param name="command">The command containing Id(Guid)</param>
        /// <returns>The removing the selected static page result as ApiResponse</returns>
        [HttpPost("RemoveStaticPage")]
        public async Task<ApiResponse> RemoveStaticPage(RemoveStaticPageCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Publishes the selected static page
        /// </summary>
        /// <param name="command">The command containing Id(Guid)</param>
        /// <returns>The publishing the selected static page result as ApiResponse</returns>
        [HttpPost("PublishStaticPage")]
        public async Task<ApiResponse> PublishStaticPage(PublishStaticPageCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Drafts the selected static page
        /// </summary>
        /// <param name="command">The command containing Id(Guid)</param>
        /// <returns>The drafting the selected static page result as ApiResponse</returns>
        [HttpPost("DraftStaticPage")]
        public async Task<ApiResponse> DraftStaticPage(DraftStaticPageCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
