using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Identity.User
{
    public class ChangeUserSettingsRequest
    {
        public string? UserName { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public bool IsChangeImage { get; set; }
        public string? Dir { get; set; }
    }
}
