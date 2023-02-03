using Clinics.Domain.Abstractions.Interfaces;

namespace Clinics.Domain.Aggregates.PaymentAggregate.Events
{
    internal record PaymentCreatedDomainEvent : IDomainEvent
    {
        public Payment Payment { get; }

        public PaymentCreatedDomainEvent(Payment session)
        {
            Payment = session;
        }
    }
}
