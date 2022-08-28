using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Domain.Aggregates.PatientAggregate.Events
{
    internal record PatientInactivatedDomainEvent : IDomainEvent
    {
        public PatientId PatientId { get; }

        public PatientInactivatedDomainEvent(PatientId patientId)
        {
            PatientId = patientId;
        }
    }
}
