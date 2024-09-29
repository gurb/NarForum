using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SmtpSetting.Queries
{
	public class SmtpSettingsDTO
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string? Server { get; set; }
		public int Port { get; set; }
		public string? Username { get; set; }
		public string? Password { get; set; }
		public int Timeout { get; set; }
	}
}
