using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.Heading.Queries;
using Application.Features.TrackingLog.Queries.GetTrackingLog;
using AutoMapper;
using MediatR;

namespace Application.Features.TrackingLog.Queries.GetTrackingLogs
{
    public class GetTrackingLogsQueryHandler : IRequestHandler<GetTrackingLogsQuery, List<TrackingLogDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ITrackingLogRepository _trackingLogRepository;
        private readonly IHeadingRepository _headingRepository;

        public GetTrackingLogsQueryHandler(IMapper mapper, ITrackingLogRepository trackingLogRepository, IHeadingRepository headingRepository)
        {
            _mapper = mapper;
            _trackingLogRepository = trackingLogRepository;
            _headingRepository = headingRepository;
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
				predicate = predicate.And(x => x.DateTime >= request.DateTime && x.DateTime <= request.DateTime.AddDays(7));
			}
			else if (request.DateType == TrackingLogDateType.MONTH)
			{
				predicate = predicate.And(x => x.DateTime.Year == request.DateTime.Year && x.DateTime.Month == request.DateTime.Month);
			}
            else if (request.DateType == TrackingLogDateType.YEAR)
            {
                predicate = predicate.And(x => x.DateTime.Year == request.DateTime.Year);
			}

            if (request.TrackingType != Models.Enums.TrackingType.NONE)
            {
                predicate = predicate.And(x => x.Type == (Domain.Models.Enums.TrackingType)request.TrackingType);
            }

            var trackingLogs = await _trackingLogRepository.GetAllAsync(predicate);


            List<TrackingLogDTO> data = new List<TrackingLogDTO>();

            if (request.DateType == TrackingLogDateType.DAY && request.TimeZone is not null)
            {
				var logsInClientTimeZone = trackingLogs
				    .Where(x => TimeZoneInfo.ConvertTimeFromUtc(x.DateTime, clientTimeZone).Date == request.DateTime.Date)
				    .ToList();

                data = _mapper.Map<List<TrackingLogDTO>>(logsInClientTimeZone);
			}
			else if (request.DateType == TrackingLogDateType.MONTH && request.TimeZone is not null)
			{
                foreach (var log in trackingLogs)
                {
                    log.DateTime = TimeZoneInfo.ConvertTimeFromUtc(log.DateTime, clientTimeZone).Date;
				}
                data = _mapper.Map<List<TrackingLogDTO>>(trackingLogs);
            }
            else if (request.DateType == TrackingLogDateType.WEEK && request.TimeZone is not null)
			{
				foreach (var log in trackingLogs)
				{
					log.DateTime = TimeZoneInfo.ConvertTimeFromUtc(log.DateTime, clientTimeZone).Date;
				}
                data = _mapper.Map<List<TrackingLogDTO>>(trackingLogs);
            }
            else
            {
                data = _mapper.Map<List<TrackingLogDTO>>(trackingLogs);
            }


            if (request.IncludeTarget)
            {
                if (request.TrackingType == Models.Enums.TrackingType.HEADING)
                {
                    var predicateHeading = PredicateBuilder.True<Domain.Heading>();

                    List<Guid?> headingIds = trackingLogs.Where(x => x.Type == Domain.Models.Enums.TrackingType.HEADING).Select(x => x.TargetId).ToList();
                    headingIds = headingIds.Distinct().ToList();

                    if (headingIds is not null && headingIds.Count > 0)
                    {
                        predicateHeading = predicateHeading.And(x => headingIds.Contains(x.Id));

                        var headings = await _headingRepository.GetAllAsync(predicateHeading);

                        foreach (var log in data)
                        {
                            var heading = headings.FirstOrDefault(x => x.Id == log.TargetId);

                            if(heading is not null)
                            {
                                log.Heading = new HeadingDTO
                                {
                                    Title = heading.Title,
                                };
                            }
                            
                        }
                    }

                }
            }


            return data;
        }
    }
}
