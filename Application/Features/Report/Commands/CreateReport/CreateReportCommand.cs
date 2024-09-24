using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Report.Commands.CreateReport
{
    public class CreateReportCommand: IRequest<ApiResponse>
    {
        public string? Title { get; set; }
        public string? Message { get; set; }
        public Guid? PostId { get; set; }
        public Guid? HeadingId { get; set; }
        public int HeadingIndex { get; set; }
    }
}
