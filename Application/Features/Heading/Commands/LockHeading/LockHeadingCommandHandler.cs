using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Models;
using MediatR;


namespace Application.Features.Heading.Commands.LockHeading
{
    public class LockHeadingCommandHandler : IRequestHandler<LockHeadingCommand, ApiResponse>
    {

        private readonly IHeadingRepository _headingRepository;
        private readonly IUserService _userService;

        public LockHeadingCommandHandler(IHeadingRepository headingRepository, IUserService userService)
        {
            _headingRepository = headingRepository;
            _userService = userService;
        }

        public async Task<ApiResponse> Handle(LockHeadingCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                if(request.Id != null)
                {
                    var heading = await _headingRepository.GetByIdAsync(request.Id.Value, true);

                    var user = await _userService.GetCurrentUser();

                    if (user != null)
                    {
                        heading.IsLock = !heading.IsLock;
                        await _headingRepository.UpdateAsync(heading);
                        response.Message = "Heading is locked.";
                    }
                }
                else
                {
                    response.Message = "Heading id cannot be null";
                    response.IsSuccess = false;
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
