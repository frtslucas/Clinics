using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;

namespace Clinics.Domain.Aggregates.SessionAggregate.Events
{
    internal record SessionPaymentAddedToSessionDomainEvent : IDomainEvent
    {
        public SessionId SessionId { get; }
        public SessionPaymentId PaymentId { get; }

        public SessionPaymentAddedToSessionDomainEvent(SessionId sessionId, SessionPaymentId paymentId)
        {
            SessionId = sessionId;
            PaymentId = paymentId;
        }
    }
}
