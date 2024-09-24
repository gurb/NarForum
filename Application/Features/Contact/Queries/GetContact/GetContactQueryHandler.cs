using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;


namespace Application.Features.Contact.Queries.GetContact
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ContactDTO>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public GetContactQueryHandler(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<ContactDTO> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            Domain.Contact contact;

            if (request.Id != null)
            {
                contact = await _contactRepository.GetByIdAsync(request.Id.Value);

                if (contact != null)
                {
                    var data = _mapper.Map<ContactDTO>(contact);

                    return data;
                }
                else
                {
                    throw new Exception("Not found");
                }
            }
            else
            {
                throw new Exception("Not found");
            }
        }


    }
}
