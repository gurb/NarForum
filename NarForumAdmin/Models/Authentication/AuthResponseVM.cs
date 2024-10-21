namespace NarForumAdmin.Models.Authentication
{
    public class AuthResponseVM
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; }
    }
}
