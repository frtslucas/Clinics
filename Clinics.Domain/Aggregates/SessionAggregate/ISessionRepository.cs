using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;

namespace Clinics.Domain.Aggregates.SessionAggregate
{
    public interface ISessionRepository : IRepository<Session, SessionId>
    {
    }
}
