using Domain.Base;
using Domain.Enums;


namespace Domain
{
    public class Contact: BaseEntity
    {
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? WebSite { get; set; }
        public ContactType Type { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
