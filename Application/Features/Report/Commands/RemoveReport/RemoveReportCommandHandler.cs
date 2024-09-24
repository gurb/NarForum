using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;
using System.Text;

namespace Application.Features.Report.Commands.RemoveReport
{
    public class RemoveReportCommandHandler : IRequestHandler<RemoveReportCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;

        public RemoveReportCommandHandler(IMapper mapper, IReportRepository reportRepository, IUserService userService)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
        }

        public async Task<ApiResponse> Handle(RemoveReportCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                if(request.Id == null)
                {
                    response.Message = "Report id is null.";
                    response.IsSuccess = false;
                    return response;
                }

                var report = await _reportRepository.GetByIdAsync(request.Id.Value, true);

                if (report != null)
                {
                    report.IsActive = !report.IsActive;
                    await _reportRepository.UpdateAsync(report);
                    response.Message = "Report is removed.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Report not found.";
                }
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
