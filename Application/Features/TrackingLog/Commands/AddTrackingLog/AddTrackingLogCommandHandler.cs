using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.TrackingLog.Commands.AddTrackingLog
{
    public class AddTrackingLogCommandHandler : IRequestHandler<AddTrackingLogCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITrackingLogRepository _trackingLogRepository;

        public AddTrackingLogCommandHandler(IMapper mapper, ITrackingLogRepository trackingLogRepository)
        {
            _mapper = mapper;
            _trackingLogRepository = trackingLogRepository;
        }

        public async Task<ApiResponse> Handle(AddTrackingLogCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var predicate = PredicateBuilder.True<Domain.TrackingLog>();

                var trackingLog = _mapper.Map<Domain.TrackingLog>(request);
                trackingLog.DateTime = DateTime.UtcNow;
                trackingLog.Browser = request.Browser;

                await _trackingLogRepository.AddAsync(trackingLog);

                response.Message = "Tracking log is added.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
