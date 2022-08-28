namespace Clinics.Domain.Abstractions.Interfaces
{
    public interface IFactory<TAggregate, TIdentifier> : IFactory<TAggregate, TIdentifier, Guid>
        where TAggregate : IAggregateRoot<TIdentifier>
        where TIdentifier : IIdentifier<Guid>, new()
    {
    }

    public interface IFactory<TAggregate, TIdentifier, TIdType>
        where TAggregate : IAggregateRoot<TIdentifier, TIdType>
        where TIdentifier : IIdentifier<TIdType>, new()
    {
    }
}
