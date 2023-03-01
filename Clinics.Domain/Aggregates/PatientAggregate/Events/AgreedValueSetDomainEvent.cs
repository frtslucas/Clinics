using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Shared;

namespace Clinics.Domain.Aggregates.PatientAggregate.Events
{
    internal record AgreedValueSetDomainEvent : IDomainEvent
    {
        public PatientId PatientId { get; }
        public Value Value { get; }

        public AgreedValueSetDomainEvent(PatientId patientId, Value value)
        {
            PatientId = patientId;
            Value = value;
        }
    }
}
