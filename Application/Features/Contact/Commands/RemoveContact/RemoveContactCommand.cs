using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contact.Commands.RemoveContact
{
    public class RemoveContactCommand : IRequest<ApiResponse>
    {
        public Guid? Id { get; set; }
    }
}
