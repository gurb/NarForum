using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ForumSettings
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? ForumUrl { get; set; }

        public bool IsShowConsentCookie { get; set; }
    }
}
