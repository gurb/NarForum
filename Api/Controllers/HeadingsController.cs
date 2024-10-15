using Application.Features.Heading.Commands.CreateHeading;
using Application.Features.Heading.Commands.LockHeading;
using Application.Features.Heading.Commands.PinHeading;
using Application.Features.Heading.Commands.RemoveHeading;
using Application.Features.Heading.Commands.UpdateHeading;
using Application.Features.Heading.Queries;
using Application.Features.Heading.Queries.GetHeading;
using Application.Features.Heading.Queries.GetHeadings;
using Application.Features.Heading.Queries.GetHeadingsWithPagination;
using Application.Models;
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

        /// <summary>
        /// Gets all headings.
        /// </summary>
        /// <returns>The getting all headings result as the list of HeadingDTO.</returns>
        [HttpGet]
        public async Task<List<HeadingDTO>> Get()
        {
            var headings = await _mediator.Send(new GetHeadingsQuery());

            return headings;
        }

        /// <summary>
        /// Gets heading by heading id as guid
        /// </summary>
        /// <param name="HeadingId">HeadingId(Guid)</param>
        /// <returns>The getting heading result as HeadingDTO.</returns>
        [AllowAnonymous]
        [HttpGet("GetHeadingById")]
        public async Task<HeadingDTO> GetHeadingById(Guid HeadingId)
        {
            var query = new GetHeadingQuery
            {
                HeadingId = HeadingId
            };

            var heading = await _mediator.Send(query);

            return heading;
        }

        /// <summary>
        /// Gets headings by category id.
        /// </summary>
        /// <param name="CategoryId">CategoryId(Guid)</param>
        /// <returns>The getting headings result as the list of HeadingDTO.</returns>
        [AllowAnonymous]
        [HttpGet("GetHeadingsByCategoryId")]
        public async Task<List<HeadingDTO>> GetHeadingsByCategoryId(Guid CategoryId)
        {
            var query = new GetHeadingsQuery
            {
                CategoryId = CategoryId
            };

            var headings = await _mediator.Send(query);

            return headings;
        }

        /// <summary>
        /// Gets headings by category name.
        /// </summary>
        /// <param name="CategoryName">CategoryName(string)</param>
        /// <returns>The getting headings result as the list of HeadingDTO.</returns>
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

        /// <summary>
        /// Gets headings with server-side pagination.
        /// </summary>
        /// <param name="request">The request containing UserName(string), CategoryName(string), SortType(SortType as enum), 
        /// IsComponent(bool), StartDate(DateTime), EndDate(DateTime), SearchTitle(string), SearchUser(string), CategoryId(Guid),
        /// PageIndex(int) and PageSize(int).</param>
        /// <returns>The getting the part of the list of headings and total size of the headings as HeadingsPaginationDTO.</returns>
        [AllowAnonymous]
        [HttpPost("GetHeadingsWithPagination")]
        public async Task<HeadingsPaginationDTO> GetHeadingsWithPagination(GetHeadingsWithPaginationQuery request)
        {
            var headings = await _mediator.Send(request);

            return headings;
        }


        /// <summary>
        /// Gets headings with server-side pagination by CategoryId, pageIndex and pageSize.
        /// </summary>
        /// <param name="CategoryId">CategoryId(Guid)</param>
        /// <param name="pageIndex">pageIndex(int)</param>
        /// <param name="pageSize">pageSize(int)</param>
        /// <returns>The getting the part of the list of headings and total size of the headings as HeadingsPaginationDTO.</returns>
        [AllowAnonymous]
        [HttpGet("GetHeadingsByCategoryIdWithPagination")]
        public async Task<HeadingsPaginationDTO> GetHeadingsByCategoryIdWithPagination(Guid CategoryId, int pageIndex, int pageSize)
        {
            var query = new GetHeadingsWithPaginationQuery
            {
                CategoryId = CategoryId,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var posts = await _mediator.Send(query);

            return posts;
        }

        /// <summary>
        /// Gets headings with server-side pagination by Username, pageIndex and pageSize.
        /// </summary>
        /// <param name="UserName">UserName(string)</param>
        /// <param name="pageIndex">pageIndex(int)</param>
        /// <param name="pageSize">pageSize(int)</param>
        /// <returns>The getting the part of the list of headings and total size of the headings as HeadingsPaginationDTO.</returns>
        [AllowAnonymous]
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


        /// <summary>
        /// Creates a new heading.
        /// </summary>
        /// <param name="command">The command containing Title(string), Description(string), CategoryId(Guid) and Content(string) fields.</param>
        /// <returns>The creating a new heading result as ApiResponse.</returns>
        [HttpPost]
        public async Task<ApiResponse> Create(CreateHeadingCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Removes the selected heading
        /// </summary>
        /// <param name="command">The command containing Id(guid).</param>
        /// <returns>The removing the selected heading result as ApiResponse.</returns>
        [HttpPost("RemoveHeading")]
        public async Task<ActionResult> RemoveHeading(RemoveHeadingCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Updates the selected heading.
        /// </summary>
        /// <param name="command">The command containing Id(guid), Title(string), Content(string) fields.</param>
        /// <returns>The updating the selected heading result as ApiResponse.</returns>
        [HttpPost("UpdateHeading")]
        public async Task<ApiResponse> UpdateHeading(UpdateHeadingCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Locks the selected heading.
        /// </summary>
        /// <param name="command">The command containing Id(guid).</param>
        /// <returns>The locking the selected heading result as ApiResponse.</returns>
        [HttpPost("LockHeading")]
        public async Task<ApiResponse> LockHeading(LockHeadingCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }


        /// <summary>
        /// Pins the selected heading.
        /// </summary>
        /// <param name="command">The command containing Id(guid)</param>
        /// <returns>The pinning the selected heading result as ApiResponse.</returns>
        [HttpPost("PinHeading")]
        public async Task<ApiResponse> PinHeading(PinHeadingCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
