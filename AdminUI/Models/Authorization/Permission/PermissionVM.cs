using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminUI.Models.Authentication.Permission;

public class PermissionVM
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
    public bool IsGranted { get; set; }
    public string? ParentPermissionId { get; set; }
    public string? RoleId { get; set; }
    public string? PermissionDefinitionId { get; set; }
}
