using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Contact.Commands.CreateContact
{
    public class CreateContactCommandHandler: IRequestHandler<CreateContactCommand, ApiResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public CreateContactCommandHandler(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<ApiResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var contact = _mapper.Map<Domain.Contact>(request);
                
                await _contactRepository.CreateAsync(contact);

                response.Message = "Contact is created.";
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
