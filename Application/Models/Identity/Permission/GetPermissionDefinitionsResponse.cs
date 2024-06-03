using Application.Models.Identity.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Identity.Permission
{
    public class GetPermissionDefinitionsResponse
    {
        public List<PermissionDefinitionDTO>? PermissionDefinitions { get; set; }
    }
}
