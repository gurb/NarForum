using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Report.Queries.GetReport
{
    public class GetReportQueryHandler: IRequestHandler<GetReportQuery, ReportDTO>
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;

        public GetReportQueryHandler(IMapper mapper, IReportRepository reportRepository)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
        }

        public async Task<ReportDTO> Handle(GetReportQuery request, CancellationToken cancellationToken)
        {
            Domain.Report report;

            if (request.Id != null)
            {
                report = await _reportRepository.GetByIdAsync(request.Id.Value);

                if(report != null)
                {
                    var data = _mapper.Map<ReportDTO>(report);

                    return data;
                }
                else
                {
                    throw new Exception("Not found");
                }
            }
            else
            {
                throw new Exception("Not found");
            }
        }
    }
}
