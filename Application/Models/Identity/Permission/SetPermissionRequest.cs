namespace Application.Models.Identity.Permission
{
    public class SetPermissionRequest
    {
        public string? PermissionId { get; set; }
        public bool Value { get; set; }
    }
}
