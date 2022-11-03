using Clinics.Domain.Abstractions.Interfaces;

namespace Clinics.Domain.Aggregates.SessionAggregate.Events
{
    internal record SessionCreatedDomainEvent : IDomainEvent
    {
        public Session Session { get; }

        public SessionCreatedDomainEvent(Session session)
        {
            Session = session;
        }
    }
}
