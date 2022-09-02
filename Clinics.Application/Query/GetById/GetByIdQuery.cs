using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Query.GetById
{
    public class GetByIdQuery<TResult> : GetByIdQuery<TResult, Guid>, IQuery<TResult>
    {
    }

    public class GetByIdQuery<TResult, TIdType> : IQuery<TResult>
    {
        public TIdType Id { get; set; } = default!;
    }
}
