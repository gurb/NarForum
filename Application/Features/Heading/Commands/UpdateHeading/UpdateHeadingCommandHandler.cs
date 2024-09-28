using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;


namespace Application.Features.Heading.Commands.UpdateHeading
{
    public class UpdateHeadingCommandHandler : IRequestHandler<UpdateHeadingCommand, ApiResponse>
    {
        private readonly IHeadingRepository _HeadingRepository;

        public UpdateHeadingCommandHandler(IHeadingRepository headingRepository)
        {
            _HeadingRepository = headingRepository;
        }

        public async Task<ApiResponse> Handle(UpdateHeadingCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();
            
            try
            {
                if(request.Id != null)
                {
                    var heading = await _HeadingRepository.GetByIdAsync(request.Id.Value, true);

                    if (heading != null) 
                    {
                        heading.Title = request.Title;
                        if(request.CategoryId != null)
                        {
                            heading.CategoryId = request.CategoryId.Value;
                        }

                        await _HeadingRepository.UpdateAsync(heading);
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Heading Id is null";
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
