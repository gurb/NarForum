using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Identity.Models;

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
