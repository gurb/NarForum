using Application.Contracts.Persistence;
using Application.Extensions.Core;
using Application.Features.Contact.Queries.GetContact;
using Application.Features.Report.Queries.GetReportsWithPagination;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contact.Queries.GetContactsWithPagination
{
    public class GetContactsWithPaginationQueryHandler : IRequestHandler<GetContactsWithPaginationQuery, ContactsPaginationDTO>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public GetContactsWithPaginationQueryHandler(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<ContactsPaginationDTO> Handle(GetContactsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Contact> contacts;

            var predicate = PredicateBuilder.True<Domain.Contact>();

            if (request.Subject != null)
            {
                predicate = predicate.And(x => x.Subject!.Contains(request.Subject));
            }

            if(request.Type != null)
            {
                predicate = predicate.And(x => x.Type == request.Type);
            }

            contacts = await _contactRepository.GetWithPagination(predicate, request.PageIndex.Value, request.PageSize.Value);

            var data = _mapper.Map<List<ContactDTO>>(contacts);

            ContactsPaginationDTO dto = new ContactsPaginationDTO
            {
                Contacts = data,
                TotalCount = _contactRepository.GetCount(predicate)
            };

            return dto;
        }
    }
}
