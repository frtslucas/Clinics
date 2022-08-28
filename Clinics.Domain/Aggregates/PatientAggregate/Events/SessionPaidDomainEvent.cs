using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Domain.Aggregates.PatientAggregate.Events
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
