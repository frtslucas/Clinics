using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.SessionAggregate;
using Clinics.Application.Query.Repository;
using Microsoft.EntityFrameworkCore;

namespace Clinics.Infrastructure.EntityFramework.Query.QueryRepository
{
    internal sealed class SessionQueryRepository : BaseQueryRepository<SessionQueryModel>, IQueryRepository<SessionQueryModel>, ISessionQueryRepository
    {
        public SessionQueryRepository(QueryDbContext dbContext)
            : base(dbContext.Sessions,
                  dbContext.Sessions
                    .Include(s => s.Patient)
                    .Include(s => s.Payments))
        {
        }
    }
}
