using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.RemoveCategory
{
    public class RemoveCategoryCommand : IRequest<Guid>
    {
        public Guid CategoryId { get; set; }
    }
}
