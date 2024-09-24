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

        [HttpPost]
        public async Task<List<ReportDTO>> Get(GetReportsQuery request)
        {
            var reports = await _mediator.Send(request);
            return reports;
        }

        [HttpPost("GetReport")]
        public async Task<ReportDTO> GetReport(GetReportQuery request)
        {
            var report = await _mediator.Send(request);

            return report;
        }

        [HttpPost("GetReportsWithPagination")]
        public async Task<ReportsPaginationDTO> GetReportsWithPagination(GetReportsWithPaginationQuery request)
        {
            var dto = await _mediator.Send(request);

            return dto;
        }

        [HttpPost("CreateReport")]
        public async Task<ApiResponse> CreateReport(CreateReportCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

        [HttpPost("RemoveReport")]
        public async Task<ApiResponse> RemoveBlogPost(RemoveReportCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
