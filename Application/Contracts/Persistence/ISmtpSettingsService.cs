using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
	public interface ISmtpSettingsService
	{
		Task AddAsync(SmtpSettings Entity);
		Task UpdateAsync(SmtpSettings Entity);
		Task<SmtpSettings?> GetAsync();
	}
}
