using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class PermissionDefinition
    {
        [Key]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }

        [ForeignKey("ParentPermissionDefinitionId")]
        public PermissionDefinition? Parent { get; set; }
        public string? ParentPermissionDefinitionId { get; set; }
    }
}
