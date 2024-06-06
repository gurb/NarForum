using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminUI.Models.Authorization.Permission;

public class AddPermissionDefinitionRequestVM
{
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string? ParentPermissionDefinitionId { get; set; }
}
