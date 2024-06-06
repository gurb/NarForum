using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminUI.Models.Authorization.Permission;

public class GetPermissionsResponseVM
{
    public List<PermissionVM>? Permissions { get; set; }
}
