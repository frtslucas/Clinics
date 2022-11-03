namespace Clinics.Application.Abstractions.Interfaces
{
    public interface ISummaryDTO : IAggregateRootDTO
    { 
    }

    public interface ISummaryDTO<TIdType> : IAggregateRootDTO<TIdType>
    { 
    }

    public interface IAggregateRootDTO : IAggregateRootDTO<Guid>
    {
    }

    public interface IAggregateRootDTO<TIdType> : IEntityDTO<TIdType>
    {
    }

    public interface IEntityDTO : IEntityDTO<Guid>
    {
    }

    public interface IEntityDTO<TIdType> : IDTO
    {
        TIdType Id { get; set; }
    }

    public interface IDTO
    {
    }
}
