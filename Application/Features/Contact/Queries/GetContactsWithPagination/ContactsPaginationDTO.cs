using Application.Features.Contact.Queries.GetContact;

namespace Application.Features.Contact.Queries.GetContactsWithPagination
{
    public class ContactsPaginationDTO
    {
        public List<ContactDTO>? Contacts { get; set; }
        public int TotalCount { get; set; }
    }
}
