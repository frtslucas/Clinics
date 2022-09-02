using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Abstractions
{
    public class BaseQueryModel : BaseQueryModel<Guid>, IQueryModel
    {
    }

    public class BaseQueryModel<TIdType> : IQueryModel<TIdType>
        where TIdType : notnull
    {
        public TIdType Id { get; set; } = default!;
    }
}
