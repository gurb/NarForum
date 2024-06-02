
namespace Application.Models.Identity.Role
{
    public class AddRoleRequest
    {
        public string Id { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
    }
}
