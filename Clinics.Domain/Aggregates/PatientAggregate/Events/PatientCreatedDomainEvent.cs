using Clinics.Domain.Abstractions.Interfaces;

namespace Clinics.Domain.Aggregates.PatientAggregate.Events
{
    public record PatientCreatedDomainEvent : IDomainEvent
    {
        public Patient Patient { get; }

        public PatientCreatedDomainEvent(Patient patient)
        {
            Patient = patient;
        }
    }
}
