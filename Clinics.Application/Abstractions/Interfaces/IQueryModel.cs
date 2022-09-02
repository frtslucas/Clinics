namespace Clinics.Application.Abstractions.Interfaces
{
    public interface IQueryModel : IQueryModel<Guid>
    {
    }

    public interface IQueryModel<TIdType>
        where TIdType : notnull
    {
        TIdType Id { get; set; }
    }
}
