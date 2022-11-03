using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.SessionAggregate;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Clinics.Infrastructure.EntityFramework.Command.Repositories
{
    internal sealed class SessionRepository : BaseRepository<Session, SessionId>, ISessionRepository, IRepository<Session, SessionId>
    {
        public SessionRepository(CommandDbContext dbContext) : base(dbContext.Sessions, dbContext.Sessions.Include(s => s.Payments))
        {
        }
    }
}
