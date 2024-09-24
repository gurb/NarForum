using Domain.Enums;

namespace Application.Features.Contact.Queries.GetContact
{
    public class ContactDTO
    {
        public Guid? Id { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? WebSite { get; set; }
        public ContactType Type { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
