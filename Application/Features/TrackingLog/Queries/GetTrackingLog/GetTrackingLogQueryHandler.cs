using Application.Contracts.Persistence;
using Application.Extensions.Core;
using AutoMapper;
using MediatR;

namespace Application.Features.TrackingLog.Queries.GetTrackingLog
{
    public class GetTrackingLogQueryHandler : IRequestHandler<GetTrackingLogQuery, TrackingLogDTO>
    {
        private readonly IMapper _mapper;
        private readonly ITrackingLogRepository _trackingLogRepository;
        public GetTrackingLogQueryHandler(IMapper mapper, ITrackingLogRepository trackingLogRepository)
        {
            _mapper = mapper;
            _trackingLogRepository = trackingLogRepository;
        }

        public async Task<TrackingLogDTO> Handle(GetTrackingLogQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateBuilder.True<Domain.TrackingLog>();

            if (request.Id is not null)
            {
                predicate = predicate.And(x => x.Id == request.Id);
            }
            else
            {
                return null;
            }

            var blogCategories = await _trackingLogRepository.GetAsync(predicate);

            var data = _mapper.Map<TrackingLogDTO>(blogCategories);

            return data;
        }
    }
}
