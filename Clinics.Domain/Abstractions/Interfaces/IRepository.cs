using System.Linq.Expressions;

namespace Clinics.Domain.Abstractions.Interfaces
{
    public interface IRepository<TAggregateRoot, TIdentifier> : IRepository<TAggregateRoot, TIdentifier, Guid>
        where TAggregateRoot : IAggregateRoot<TIdentifier>
        where TIdentifier : IIdentifier<Guid>, new()
    {
    }

    public interface IRepository<TAggregateRoot, TIdentifier, TIdType>
        where TAggregateRoot : IAggregateRoot<TIdentifier, TIdType>
        where TIdentifier : IIdentifier<TIdType>, new()
    {
        Task<TAggregateRoot?> FindByIdAsync(TIdentifier id);
        Task<bool> ExistsByIdAsync(TIdentifier id);
        Task<long> CountAsync(Expression<Func<TAggregateRoot, bool>>? filter = null);

        Task AddAsync(TAggregateRoot aggregate);
        Task UpdateAsync(TAggregateRoot aggregate);
        Task DeleteAsync(TAggregateRoot aggregate);
    }
}
