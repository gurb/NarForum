using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Report.Commands.RemoveReport
{
    public class RemoveReportCommand : IRequest<ApiResponse>
    {
        public Guid? Id { get; set; }
    }
}
