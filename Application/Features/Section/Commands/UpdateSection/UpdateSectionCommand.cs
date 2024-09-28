using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Section.Commands.UpdateSection;

public class UpdateSectionCommand : IRequest<ApiResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int OrderIndex { get; set; }
}
