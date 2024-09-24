using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Report.Commands.CreateReport
{
    public class CreateReportCommandHandler: IRequestHandler<CreateReportCommand, ApiResponse>
    {

        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;
        private readonly IUserService _userService;

        public CreateReportCommandHandler(IMapper mapper, IReportRepository reportRepository, IUserService userService)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
            _userService = userService;
        }

        public async Task<ApiResponse> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var user = await _userService.GetCurrentUser();

                var report = _mapper.Map<Domain.Report>(request);
                if (user.Id != null)
                {
                    report.UserName = user.UserName;
                    report.SenderUserId = new Guid(user.Id);
                }

                await _reportRepository.CreateAsync(report);

                response.Message = "Report is created.";
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
