using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
	public class SmtpSettingsService : ISmtpSettingsService
	{
		protected readonly ForumDbContext _context;
		public SmtpSettingsService(ForumDbContext context)
		{
			_context = context;
		}
		public async Task AddAsync(SmtpSettings Entity)
		{
			await _context.AddAsync(Entity);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(SmtpSettings entity)
		{
			_context.Update(entity);
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task<SmtpSettings?> GetAsync()
		{
			return await _context.SmtpSettings.FirstOrDefaultAsync();
		}
	}
}
