using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ForumSettingsService : IForumSettingsService
    {
        protected readonly ForumDbContext _context;
        public ForumSettingsService(ForumDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ForumSettings Entity)
        {
            await _context.AddAsync(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ForumSettings entity)
        {
            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
       
        public async Task<ForumSettings?> GetAsync()
        {
            return await _context.ForumSettings.FirstOrDefaultAsync();
        }
    }
}
