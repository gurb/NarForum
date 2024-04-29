using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Identity.User
{
    public class UserInfoResponse
    {
        public string UserName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime RegisterDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PostCounter { get; set; }
        public int HeadingCounter { get; set; }
    }
}
