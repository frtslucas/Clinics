using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Domain.Aggregates.PatientAggregate.Events
{
    internal record EstimatedMonthSessionsSetDomainEvent : IDomainEvent
    {
        public PatientId PatientId { get; }
        public byte EstimatedMonthSessions { get; }

        public EstimatedMonthSessionsSetDomainEvent(PatientId patientId, byte estimatedMonthSessions)
        {
            PatientId = patientId;
            EstimatedMonthSessions = estimatedMonthSessions;
        }
    }
}
