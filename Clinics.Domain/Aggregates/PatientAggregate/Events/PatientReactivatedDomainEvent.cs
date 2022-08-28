using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Domain.Aggregates.PatientAggregate.Events
{
    internal record PatientReactivatedDomainEvent : IDomainEvent
    {
        public PatientId PatientId { get; }

        public PatientReactivatedDomainEvent(PatientId patientId)
        {
            PatientId = patientId;
        }
    }
}
