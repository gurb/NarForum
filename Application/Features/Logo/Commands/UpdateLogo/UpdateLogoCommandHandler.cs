using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;


namespace Application.Features.Logo.Commands.UpdateLogo
{
    public class UpdateLogoCommandHandler : IRequestHandler<UpdateLogoCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILogoService _logoService;

        public UpdateLogoCommandHandler(IMapper mapper, ILogoService logoService)
        {
            _mapper = mapper;
            _logoService = logoService;
        }
        public async Task<ApiResponse> Handle(UpdateLogoCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var logo = await _logoService.GetAsync();

                if (logo != null)
                {
                    logo.AltText = request.AltText;
                    logo.Path = request.Path;
                    logo.Base64 = request.Base64;
                    logo.Text = request.Text;

                    await _logoService.UpdateAsync(logo);
                    response.Message = "Logo is updated";
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
