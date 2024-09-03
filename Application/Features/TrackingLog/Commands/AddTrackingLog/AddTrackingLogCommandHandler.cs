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

                var blogCategory = _mapper.Map<Domain.TrackingLog>(request);

                await _trackingLogRepository.AddAsync(blogCategory);

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
