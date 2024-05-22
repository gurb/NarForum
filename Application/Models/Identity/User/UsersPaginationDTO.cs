using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Identity.User
{
    public class UsersPaginationDTO
    {
        public List<UserInfoResponse>? Users { get; set; }
        public int TotalCount { get; set; }
    }
}
