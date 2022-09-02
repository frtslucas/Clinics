namespace Clinics.Domain.Abstractions.Interfaces
{
    public interface IEntity<TIdentifier> : IEntity<TIdentifier, Guid>
        where TIdentifier : IIdentifier<Guid>, new()
    {
    }

    public interface IEntity<TIdentifier, TIdType>
        where TIdentifier : IIdentifier<TIdType>, new()
    {
        TIdentifier Id { get; }
    }
}
