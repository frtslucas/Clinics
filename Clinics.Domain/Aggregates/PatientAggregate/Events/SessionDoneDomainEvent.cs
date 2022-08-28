using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Domain.Aggregates.PatientAggregate.Events
{
    internal record SessionDoneDomainEvent : IDomainEvent
    {
        public PatientId PatientId { get; }
        public SessionId SessionId { get; }

        public SessionDoneDomainEvent(PatientId patientId, SessionId sessionId)
        {
            PatientId = patientId;
            SessionId = sessionId;
        }
    }
}
