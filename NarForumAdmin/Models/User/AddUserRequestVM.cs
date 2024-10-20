namespace NarForumAdmin.Models.User
{
    public class AddUserRequestVM
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }

        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}
