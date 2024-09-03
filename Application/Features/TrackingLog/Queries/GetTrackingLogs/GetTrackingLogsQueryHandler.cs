using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.TrackingLog.Queries.GetTrackingLog;
using AutoMapper;
using MediatR;

namespace Application.Features.TrackingLog.Queries.GetTrackingLogs
{
    public class GetTrackingLogsQueryHandler : IRequestHandler<GetTrackingLogsQuery, List<TrackingLogDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ITrackingLogRepository _trackingLogRepository;

        public GetTrackingLogsQueryHandler(IMapper mapper, ITrackingLogRepository trackingLogRepository)
        {
            _mapper = mapper;
            _trackingLogRepository = trackingLogRepository;
        }

        public async Task<List<TrackingLogDTO>> Handle(GetTrackingLogsQuery request, CancellationToken cancellationToken)
        {

            var predicate = PredicateBuilder.True<Domain.TrackingLog>();

            //if (!String.IsNullOrEmpty(request.SearchText))
            //{
            //    predicate = predicate.And(x => x.Name.ToLower().Contains(request.SearchText.ToLower()));
            //}

            var blogCategories = await _trackingLogRepository.GetAllAsync(predicate);

            var data = _mapper.Map<List<TrackingLogDTO>>(blogCategories);

            return data;
        }
    }
}
