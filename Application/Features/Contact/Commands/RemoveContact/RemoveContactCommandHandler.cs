using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;


namespace Application.Features.Contact.Commands.RemoveContact
{
    public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public RemoveContactCommandHandler(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<ApiResponse> Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                if (request.Id == null)
                {
                    response.Message = "Contact id is null.";
                    response.IsSuccess = false;
                    return response;
                }

                var report = await _contactRepository.GetByIdAsync(request.Id.Value, true);

                if (report != null)
                {
                    report.IsActive = !report.IsActive;
                    await _contactRepository.UpdateAsync(report);
                    response.Message = "Contact is removed.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Contact not found.";
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
