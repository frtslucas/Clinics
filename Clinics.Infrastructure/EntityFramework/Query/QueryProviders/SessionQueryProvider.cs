using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.SessionAggregate;
using Clinics.Application.Query.Providers;
using Microsoft.EntityFrameworkCore;

namespace Clinics.Infrastructure.EntityFramework.Query.QueryProviders
{
    internal sealed class SessionQueryProvider : BaseQueryProvider<SessionQueryModel>, IQueryProvider<SessionQueryModel>, ISessionQueryProvider
    {
        public SessionQueryProvider(QueryDbContext dbContext) 
            : base(dbContext.Sessions, 
                  dbContext.Sessions
                    .Include(s => s.Patient)
                    .Include(s => s.Payments))
        {
        }
    }
}
