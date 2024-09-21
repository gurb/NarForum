using Microsoft.AspNetCore.Http;

namespace BlazorUI.Models.User
{
    public class ChangeUserSettingsRequestVM
    {
        public string? UserName { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public bool IsChangeImage { get; set; }
        public string? Dir { get; set; }
    }
}
