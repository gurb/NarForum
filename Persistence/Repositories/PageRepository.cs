using Application.Contracts.Persistence;
using Domain;
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
    }
}
