using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contact.Queries.GetContact
{
    public class GetContactQuery: IRequest<ContactDTO>
    {
        public Guid? Id { get; set; }
    }
}
