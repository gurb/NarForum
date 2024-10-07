using NarForumAdmin.Models.Authorization.Role;

namespace NarForumAdmin.Models.Authorization.Role;

public class GetUserRolesResponseVM
{
    public List<RoleVM>? UserRoles { get; set; }
}
