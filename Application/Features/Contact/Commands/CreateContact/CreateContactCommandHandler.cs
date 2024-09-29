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
        private readonly IEmailSender _emailSender;

        public CreateContactCommandHandler(IMapper mapper, IContactRepository contactRepository, IEmailSender emailSender)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
            _emailSender = emailSender;
        }

        public async Task<ApiResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                var contact = _mapper.Map<Domain.Contact>(request);
                
                await _contactRepository.CreateAsync(contact);

                if(contact.Email != null && contact.NameSurname != null && contact.Subject != null && contact.Message != null)
                {
                    await _emailSender.SendMail(contact.Email, contact.NameSurname, contact.Subject, contact.Message);
                }

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
