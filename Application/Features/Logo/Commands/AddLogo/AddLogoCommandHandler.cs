using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Logo.Commands.AddLogo
{
    public class AddLogoCommandHandler : IRequestHandler<AddLogoCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILogoService _logoService;

        public AddLogoCommandHandler(IMapper mapper, ILogoService logoService)
        {
            _mapper = mapper;
            _logoService = logoService;
        }

        public async Task<ApiResponse> Handle(AddLogoCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var logo = await _logoService.GetAsync();

                if(logo == null)
                {
                    logo = _mapper.Map<Domain.Logo>(request);

                    await _logoService.AddAsync(logo);

                    response.Message = "Logo is added";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Logo is already exist";
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
