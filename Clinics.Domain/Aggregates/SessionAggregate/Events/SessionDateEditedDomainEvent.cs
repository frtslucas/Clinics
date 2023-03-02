using Clinics.Domain.Abstractions.Interfaces;

namespace Clinics.Domain.Aggregates.SessionAggregate.Events
{
    internal record SessionDateEditedDomainEvent : IDomainEvent
    {
        public Session Session { get; }

        public SessionDateEditedDomainEvent(Session session)
        {
            Session = session;
        }
    }
}
