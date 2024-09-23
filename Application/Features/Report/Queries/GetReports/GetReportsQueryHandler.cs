using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.Report.Queries.GetReport;
using AutoMapper;
using MediatR;

namespace Application.Features.Report.Queries.GetReports
{
    public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, List<ReportDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;

        public GetReportsQueryHandler(IMapper mapper, IReportRepository reportRepository)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
        }

        public async Task<List<ReportDTO>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Report> reports;

            var predicate = PredicateBuilder.True<Domain.Report>();

            if(request.PostId != null)
            {
                predicate = predicate.And(x => x.PostId == request.PostId);
            }

            if (request.HeadingId != null)
            {
                predicate = predicate.And(x => x.HeadingId == request.HeadingId);
            }

            if (request.SenderUserId != null)
            {
                predicate = predicate.And(x => x.SenderUserId == request.SenderUserId);
            }

            reports = await _reportRepository.GetAllAsync(predicate);

            // convert data objecs to DTOs
            var data = _mapper.Map<List<ReportDTO>>(reports);

            // return list of DTOs
            return data;
        }
    }
}
