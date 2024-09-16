using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Logo.Commands.RemoveLogo
{
    public class RemoveLogoCommandHandler : IRequestHandler<RemoveLogoCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILogoService _logoService;

        public RemoveLogoCommandHandler(IMapper mapper, ILogoService logoService)
        {
            _mapper = mapper;
            _logoService = logoService;
        }

        public async Task<ApiResponse> Handle(RemoveLogoCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var logo = await _logoService.GetAsync();

                if (logo != null)
                {
                    await _logoService.DeleteAsync(logo);
                    response.Message = "Logo is removed";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Logo is not found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
