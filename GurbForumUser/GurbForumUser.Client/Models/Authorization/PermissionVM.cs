namespace GurbForumUser.Client.Models.Authorization
{
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
}
