using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class Permission
    {
        [Key]
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; } 
        public string? DisplayName { get; set; }
        public bool IsGranted { get; set; }


        [ForeignKey("ParentPermissionId")]
        public Permission? Parent { get; set; }
        public string? ParentPermissionId { get; set; }


        [ForeignKey("RoleId")]
        public IdentityRole? Role { get; set; }
        public string? RoleId { get; set; }


        [ForeignKey("PermissionDefinitionId")]
        public PermissionDefinition? PermissionDefinition { get; set; }
        public string? PermissionDefinitionId { get; set; }
    }
}
