using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Identity.Permission
{
    public class GetPermissionsResponse
    {
        public List<PermissionDTO>? Permissions { get; set; }
    }
}
