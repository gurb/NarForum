using Application.Features.Contact.Queries.GetContact;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contact.Queries.GetContacts
{
    public class GetContactsQuery:  IRequest<List<ContactDTO>>
    {

    }
}
