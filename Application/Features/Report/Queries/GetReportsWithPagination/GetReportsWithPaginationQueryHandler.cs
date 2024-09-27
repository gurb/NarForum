using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.Report.Queries.GetReport;
using AutoMapper;
using MediatR;

namespace Application.Features.Report.Queries.GetReportsWithPagination
{
    public class GetReportsWithPaginationQueryHandler : IRequestHandler<GetReportsWithPaginationQuery, ReportsPaginationDTO>
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;

        public GetReportsWithPaginationQueryHandler(IMapper mapper, IReportRepository reportRepository)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
        }

        public async Task<ReportsPaginationDTO> Handle(GetReportsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Report> reports;

            var predicate = PredicateBuilder.True<Domain.Report>();

            if (request.HeadingId != null)
            {
                predicate = predicate.And(x => x.HeadingId == request.HeadingId);
            }

            if (request.SenderUserId != null)
            {
                predicate = predicate.And(x => x.SenderUserId == request.SenderUserId);
            }

            if (request.PostId != null)
            {
                predicate = predicate.And(x => x.PostId == request.PostId);
            }

            if (request.SearchUsername != null)
            {
                predicate = predicate.And(x => x.UserName.ToLower().Contains(request.SearchUsername.ToLower()));
            }

            if (request.Title != null)
            {
                predicate = predicate.And(x => x.Title.ToLower().Contains(request.Title.ToLower()));
            }

            reports = await _reportRepository.GetWithPagination(predicate, request.PageIndex.Value, request.PageSize.Value);

            var data = _mapper.Map<List<ReportDTO>>(reports);

            ReportsPaginationDTO dto = new ReportsPaginationDTO
            {
                Reports = data,
                TotalCount = _reportRepository.GetCount(predicate)
            };

            return dto;
        }
    }
}
