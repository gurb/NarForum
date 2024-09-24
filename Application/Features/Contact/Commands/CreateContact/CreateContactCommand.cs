using Application.Models;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contact.Commands.CreateContact
{
    public class CreateContactCommand: IRequest<ApiResponse>
    {
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public string? WebSite { get; set; }
        public ContactType Type { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
