using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.Heading.Queries;
using Application.Features.TrackingLog.Queries.GetTrackingLog;
using AutoMapper;
using MediatR;

namespace Application.Features.TrackingLog.Queries.GetTrackingLogsWithPagination
{
	public class GetTrackingLogsWithPaginationQueryHandler : IRequestHandler<GetTrackingLogsWithPaginationQuery, TrackingLogsPaginationDTO>
	{
		private readonly IMapper _mapper;
		private readonly ITrackingLogRepository _trackingLogRepository;
		private readonly IHeadingRepository _headingRepository;

		public GetTrackingLogsWithPaginationQueryHandler(IMapper mapper, ITrackingLogRepository trackingLogRepository, IHeadingRepository headingRepository)
        {
			_mapper = mapper;
			_trackingLogRepository = trackingLogRepository;
			_headingRepository = headingRepository;
		}
        public async Task<TrackingLogsPaginationDTO> Handle(GetTrackingLogsWithPaginationQuery request, CancellationToken cancellationToken)
		{
			var predicate = PredicateBuilder.True<Domain.TrackingLog>();

			TimeZoneInfo clientTimeZone = TimeZoneInfo.Utc;

			if (request.TimeZone is not null)
			{
				clientTimeZone = TimeZoneInfo.FindSystemTimeZoneById(request.TimeZone);
			}

			if (request.DateType == TrackingLogDateType.DAY)
			{
                predicate = predicate.And(x => x.DateTime.Date == request.DateTime.Date);
			}
			else if (request.DateType == TrackingLogDateType.WEEK)
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

			Dictionary<Guid, int> ViewCounters = new Dictionary<Guid, int>();
			foreach(var log in trackingLogs)
			{
				if(log.TargetId is not null && !ViewCounters.ContainsKey(log.TargetId.Value))
				{
					ViewCounters.Add(log.TargetId.Value, 1);
				}
				else if(log.TargetId is not null)
				{
					ViewCounters[log.TargetId.Value] += 1; 
                }
			}


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

			int TotalCount = 0;
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

						var headings = await _headingRepository.GetWithPagination(predicateHeading, request.PageIndex!.Value, request.PageSize!.Value);
						TotalCount = _headingRepository.GetCount(predicateHeading);

						foreach (var heading in headings)
						{
                            var log = data.FirstOrDefault(x => x.TargetId == heading.Id);

                            if(log is not null && log.Heading is null)
							{
								log.Heading = new HeadingDTO
                                {
                                    Title = heading.Title,
                                };
								log.ViewCounter = ViewCounters.GetValueOrDefault(heading.Id);
                            }
                        }

						data = data.Where(x => x.Heading != null).ToList();
					}

				}
			}


			TrackingLogsPaginationDTO dto = new TrackingLogsPaginationDTO
			{
				TrackingLogs = data,
				TotalCount = TotalCount,
			};

			return dto;
		}
	}
}
