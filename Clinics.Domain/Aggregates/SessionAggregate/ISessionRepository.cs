using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;

namespace Clinics.Domain.Aggregates.SessionAggregate
{
    public interface ISessionRepository : IRepository<Session, SessionId>
    {
        Task<IReadOnlyList<Session>> GetUnpaidSessionsFromPatientAsync(PatientId patientId);
        Task UpdateManyAsync(IEnumerable<Session> sessions);
    }
}
