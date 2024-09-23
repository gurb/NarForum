using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;


namespace Persistence.Repositories
{
    public class ReportRepository :  GenericRepository<Report>, IReportRepository
    {
        public ReportRepository(ForumDbContext context) : base(context)
        {

        }
    }
}
