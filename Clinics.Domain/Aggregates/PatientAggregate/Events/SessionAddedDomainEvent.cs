using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Domain.Aggregates.PatientAggregate.Events
{
    internal record SessionAddedDomainEvent : IDomainEvent
    {
        public PatientId PatientId { get; }
        public SessionId SessionId { get; }

        public SessionAddedDomainEvent(PatientId patientId, SessionId sessionId)
        {
            PatientId = patientId;
            SessionId = sessionId;
        }
    }
}
