namespace Clinics.Domain.Abstractions.Interfaces
{
    public interface IIdentifier<TIdType>
    {
        TIdType Value { get; }
    }
}
