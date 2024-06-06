using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminUI.Models.Authorization.Permission;

public class PermissionDefinitionVM
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
    public string? ParentPermissionDefinitionId { get; set; }
}
