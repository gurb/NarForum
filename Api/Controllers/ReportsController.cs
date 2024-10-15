using Application.Features.Report.Commands.CreateReport;
using Application.Features.Report.Commands.RemoveReport;
using Application.Features.Report.Queries.GetReport;
using Application.Features.Report.Queries.GetReports;
using Application.Features.Report.Queries.GetReportsWithPagination;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all reports
        /// </summary>
        /// <param name="request">The request containing Title(string), Message(string), SenderUserId(Guid), PostId(Guid), HeadingId(Guid) fields.</param>
        /// <returns>The getting all reports result as the list of ReportDTO.</returns>
        [HttpPost]
        public async Task<List<ReportDTO>> Get(GetReportsQuery request)
        {
            var reports = await _mediator.Send(request);
            return reports;
        }

        /// <summary>
        /// Gets the selected report.
        /// </summary>
        /// <param name="request">The request containing Id(Guid) field.</param>
        /// <returns>The getting the selected report result as ReportDTO.</returns>
        [HttpPost("GetReport")]
        public async Task<ReportDTO> GetReport(GetReportQuery request)
        {
            var report = await _mediator.Send(request);

            return report;
        }

        /// <summary>
        /// Gets reports with server-side pagination.
        /// </summary>
        /// <param name="request">The request containing itle(string), Message(string), SenderUserId(Guid), PostId(Guid), HeadingId(Guid), SearchUserName(string), PageIndex(int) and PageSize(int).</param>
        /// <returns>The getting the part of the list of reports and total size of the reports as ReportsPaginationDTO.</returns>
        [HttpPost("GetReportsWithPagination")]
        public async Task<ReportsPaginationDTO> GetReportsWithPagination(GetReportsWithPaginationQuery request)
        {
            var dto = await _mediator.Send(request);

            return dto;
        }

        /// <summary>
        /// Creates a new report.
        /// </summary>
        /// <param name="command">The command containing Title(string), Message(string), PostId(Guid), HeadingId(Guid), HeadingIndex(int) fields.</param>
        /// <returns>The creating a new report result as ApiResponse.</returns>
        [HttpPost("CreateReport")]
        public async Task<ApiResponse> CreateReport(CreateReportCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        /// <summary>
        /// Removes the selected report.
        /// </summary>
        /// <param name="command">The command containing Id(Guid) field.</param>
        /// <returns>The removing the selected report result as ApiResponse.</returns>
        [HttpPost("RemoveReport")]
        public async Task<ApiResponse> RemoveReport(RemoveReportCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
