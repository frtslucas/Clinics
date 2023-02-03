using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
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

        public async Task<IReadOnlyList<Session>> GetUnpaidSessionsFromPatientAsync(PatientId patientId)
        {
            return (await _aggregate.Where(a => a.PatientId == patientId && a.Paid == false).ToListAsync()).AsReadOnly();
        }

        public Task UpdateManyAsync(IEnumerable<Session> sessions)
        {
            return Task.FromResult(() => _dbSet.UpdateRange(sessions));
        }
    }
}
