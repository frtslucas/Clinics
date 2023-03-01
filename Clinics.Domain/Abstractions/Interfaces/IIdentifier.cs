namespace Clinics.Domain.Abstractions.Interfaces
{
    public interface IIdentifier : IIdentifier<Guid>
    {
    }

    public interface IIdentifier<TIdType>
    {
        TIdType Value { get; }
    }
}
