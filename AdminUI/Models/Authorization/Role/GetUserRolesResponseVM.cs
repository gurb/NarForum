using AdminUI.Models.Authorization.Role;

namespace AdminUI.Models.Authentication.Role;

public class GetUserRolesResponseVM
{
    public List<RoleVM>? UserRoles { get; set; }
}
