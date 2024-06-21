namespace Application.Models.Identity.Permission
{
    public class AddPermissionDefinitionRequest
    {
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string? ParentPermissionDefinitionId { get; set; }
    }
}
