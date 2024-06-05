using Application.Models.Identity.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminUI.Models.Authentication.Permission;

public class GetPermissionDefinitionsResponseVM
{
    public List<PermissionDefinitionVM>? PermissionDefinitions { get; set; }
}
