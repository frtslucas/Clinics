using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Shared;

namespace Clinics.Domain.Aggregates.PatientAggregate.Events
{
    internal record AgreedValueSetDomainEvent : IDomainEvent
    {
        public PatientId PatientId { get; }
        public MoneyValue MoneyValue { get; }

        public AgreedValueSetDomainEvent(PatientId patientId, MoneyValue moneyValue)
        {
            PatientId = patientId;
            MoneyValue = moneyValue;
        }
    }
}
