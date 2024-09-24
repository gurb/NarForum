using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.Contact.Queries.GetContact;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contact.Queries.GetContacts
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, List<ContactDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public GetContactsQueryHandler(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<List<ContactDTO>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Contact> contacts;

            var predicate = PredicateBuilder.True<Domain.Contact>();

            contacts = await _contactRepository.GetAllAsync(predicate);

            // convert data objecs to DTOs
            var data = _mapper.Map<List<ContactDTO>>(contacts);

            // return list of DTOs
            return data;
        }
    }
}
