using Domain.Enums;
using MediatR;

namespace Application.Features.Contact.Queries.GetContactsWithPagination
{
    public class GetContactsWithPaginationQuery : IRequest<ContactsPaginationDTO>
    {
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public ContactType? Type { get; set; }
        public string? Subject { get; set; }

        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
