using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;

namespace Clinics.Domain.Aggregates.SessionAggregate.Events
{
    internal record SessionPaidDomainEvent : IDomainEvent
    {
        public SessionId SessionId { get; }

        public SessionPaidDomainEvent(SessionId sessionId)
        {
            SessionId = sessionId;
        }
    }
}
