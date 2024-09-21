using Microsoft.AspNetCore.Http;

namespace BlazorUI.Models.User
{
    public class ChangeUserSettingsRequestVM
    {
        public string? UserName { get; set; }
        public string? ProfileImageBase64 { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public bool IsChangeImage { get; set; }
        public string? Dir { get; set; }
    }
}
