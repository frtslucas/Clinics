using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Infrastructure.EntityFramework.Command;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clinics.Infrastructure.EntityFramework.Command.Repositories
{
    internal abstract class BaseRepository<TAggregateRoot, TIdentifier> : BaseRepository<TAggregateRoot, TIdentifier, Guid>, IRepository<TAggregateRoot, TIdentifier, Guid>
        where TAggregateRoot : class, IAggregateRoot<TIdentifier, Guid>, IEntity<TIdentifier, Guid>
        where TIdentifier : IIdentifier<Guid>, new()
    {
        protected BaseRepository(DbSet<TAggregateRoot> dbSet, IQueryable<TAggregateRoot> aggregate) : base(dbSet, aggregate)
        {
        }
    }

    internal abstract class BaseRepository<TAggregateRoot, TIdentifier, TIdType> : IRepository<TAggregateRoot, TIdentifier, TIdType>
        where TAggregateRoot : class, IAggregateRoot<TIdentifier, TIdType>, IEntity<TIdentifier, TIdType>
        where TIdentifier : IIdentifier<TIdType>, new()
    {
        protected readonly IQueryable<TAggregateRoot> _aggregate;
        protected readonly DbSet<TAggregateRoot> _dbSet;

        public BaseRepository(DbSet<TAggregateRoot> dbSet, IQueryable<TAggregateRoot> aggregate)
        {
            _dbSet = dbSet;
            _aggregate = aggregate;
        }

        public async Task<TAggregateRoot?> FindByIdAsync(TIdentifier id)
        {
            return await _aggregate
                .Where(a => a.Id.Equals(id))
                .SingleOrDefaultAsync();
        }

        public async Task<bool> ExistsByIdAsync(TIdentifier id)
        {
            return await _dbSet.AnyAsync(a => a.Id.Equals(id));
        }

        public async Task<long> CountAsync(Expression<Func<TAggregateRoot, bool>>? filter = null)
        {
            var query = _dbSet.AsQueryable();

            if (filter is not null)
                query = query.Where(filter);

            return await query.CountAsync();
        }

        public async Task AddAsync(TAggregateRoot aggregate)
        {
            await _dbSet.AddAsync(aggregate);
        }

        public Task DeleteAsync(TAggregateRoot aggregate)
        {
            return Task.FromResult(() => _dbSet.Remove(aggregate));
        }

        public Task UpdateAsync(TAggregateRoot aggregate)
        {
            return Task.FromResult(() => _dbSet.Update(aggregate));
        }
    }
}
