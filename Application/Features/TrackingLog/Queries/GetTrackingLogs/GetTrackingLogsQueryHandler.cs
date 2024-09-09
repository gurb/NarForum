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

            TimeZoneInfo clientTimeZone = TimeZoneInfo.Utc;

			if (request.TimeZone is not null)
            {
				clientTimeZone = TimeZoneInfo.FindSystemTimeZoneById(request.TimeZone);
			}

            if(request.DateType == TrackingLogDateType.DAY)
            {
                predicate = predicate.And(x => x.DateTime >= request.DateTime.AddDays(-1) && x.DateTime < request.DateTime.AddDays(1));
			}
            else if(request.DateType == TrackingLogDateType.WEEK)
            {
				//predicate = predicate.And(x => x.DateTime.Date == request.DateTime);
			}
			else if (request.DateType == TrackingLogDateType.MONTH)
			{
				predicate = predicate.And(x => x.DateTime.Year == request.DateTime.Year && x.DateTime.Month == request.DateTime.Month);
			}
            else if (request.DateType == TrackingLogDateType.YEAR)
            {
                predicate = predicate.And(x => x.DateTime.Year == request.DateTime.Year);
			}

			var trackingLogs = await _trackingLogRepository.GetAllAsync(predicate);

			if (request.DateType == TrackingLogDateType.DAY && request.TimeZone is not null)
            {
				var logsInClientTimeZone = trackingLogs
				    .Where(x => TimeZoneInfo.ConvertTimeFromUtc(x.DateTime, clientTimeZone).Date == request.DateTime.Date)
				    .ToList();

                return _mapper.Map<List<TrackingLogDTO>>(logsInClientTimeZone);
			}
			if (request.DateType == TrackingLogDateType.MONTH && request.TimeZone is not null)
			{
                foreach (var log in trackingLogs)
                {
                    log.DateTime = TimeZoneInfo.ConvertTimeFromUtc(log.DateTime, clientTimeZone).Date;
				}
			}

			var data = _mapper.Map<List<TrackingLogDTO>>(trackingLogs);

            return data;
        }
    }
}
