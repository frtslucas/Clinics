namespace Clinics.Domain.Abstractions.Interfaces
{
    public interface IAggregateRoot<TIdentifier> : IAggregateRoot<TIdentifier, Guid>, IEntity<TIdentifier>
        where TIdentifier : IIdentifier<Guid>, new()
    {
    }

    public interface IAggregateRoot<TIdentifier, TIdType> : IEntity<TIdentifier, TIdType>
        where TIdentifier : IIdentifier<TIdType>, new()
    {
        int Version { get; }
        IReadOnlyList<IDomainEvent> Events { get; }
    }
}
