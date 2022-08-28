using Clinics.Domain.Abstractions.Interfaces;

namespace Clinics.Domain.Abstractions
{
    public class AggregateRoot<TIdentifier> : AggregateRoot<TIdentifier, Guid>, IAggregateRoot<TIdentifier>, IEntity<TIdentifier>
        where TIdentifier : IIdentifier<Guid>, new()
    {
        protected AggregateRoot() : base()
        {

        }

        protected AggregateRoot(TIdentifier id) : base(id)
        {
        }
    }

    public class AggregateRoot<TIdentifier, TIdType> : Entity<TIdentifier, TIdType>, IAggregateRoot<TIdentifier, TIdType>, IEntity<TIdentifier, TIdType>
        where TIdentifier : IIdentifier<TIdType>, new()
    {
        protected AggregateRoot() : base()
        {

        }

        protected AggregateRoot(TIdentifier id) : base(id)
        {
        }

        private readonly List<IDomainEvent> _events = new();
        public IReadOnlyList<IDomainEvent> Events => _events.AsReadOnly();

        private bool _versionIncremented;
        public int Version { get; private set; }

        protected virtual void AddDomainEvent(IDomainEvent domainEvent)
        {
            IncrementVersion();

            _events.Add(domainEvent);
            DomainEventsContext.AddEvent(domainEvent);
        }

        private void IncrementVersion()
        {
            if (_versionIncremented)
                return;

            Version++;
            _versionIncremented = true;
        }
    }
}
