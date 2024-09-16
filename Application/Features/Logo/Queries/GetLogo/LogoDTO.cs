using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Logo.Queries.GetLogo
{
    public class LogoDTO
    {
        public Guid? Id { get; set; }
        public string? Base64 { get; set; }
        public string? Text { get; set; }
        public string? AltText { get; set; }
        public string? Path { get; set; }
    }
}
