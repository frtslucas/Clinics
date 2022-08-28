namespace Clinics.Domain.Abstractions.Interfaces
{
    public interface IEntity<TIdentifier> : IEntity<TIdentifier, Guid>
        where TIdentifier : IIdentifier<Guid>
    {
    }

    public interface IEntity<TIdentifier, TIdType>
        where TIdentifier : IIdentifier<TIdType>
    {
        TIdentifier Id { get; }
    }
}
