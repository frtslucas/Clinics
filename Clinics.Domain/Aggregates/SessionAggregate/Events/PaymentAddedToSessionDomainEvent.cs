using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;

namespace Clinics.Domain.Aggregates.SessionAggregate.Events
{
    internal record PaymentAddedToSessionDomainEvent : IDomainEvent
    {
        public SessionId SessionId { get; }
        public PaymentId PaymentId { get; }

        public PaymentAddedToSessionDomainEvent(SessionId sessionId, PaymentId paymentId)
        {
            SessionId = sessionId;
            PaymentId = paymentId;
        }
    }
}
