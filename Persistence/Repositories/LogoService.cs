using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories
{
    public class LogoService: ILogoService
    {
        protected readonly ForumDbContext _context;

        public LogoService(ForumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Logo Entity)
        {
            await _context.AddAsync(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Logo entity)
        {
            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Logo entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
        
        public async Task<Logo?> GetAsync()
        {
            return await _context.Logos.FirstOrDefaultAsync();
        }
    }
}
