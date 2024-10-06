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
    public class PageRepository : GenericRepository<StaticPage>, IPageRepository
    {
        public PageRepository(ForumDbContext context) : base(context)
        {

        }

        public async Task<StaticPage?> GetStaticPageByUrl(string Url, bool isTrack = false)
        {
            if (isTrack)
            {
                return await _context.Set<StaticPage>().FirstOrDefaultAsync(x => x.Url.ToLower() == Url.ToLower());
            }
            return await _context.Set<StaticPage>().AsNoTracking().FirstOrDefaultAsync(x => x.Url.ToLower() == Url.ToLower());
        }
    }
}
