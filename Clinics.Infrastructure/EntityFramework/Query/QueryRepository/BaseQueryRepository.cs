using Clinics.Application.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clinics.Infrastructure.EntityFramework.Query.QueryRepository
{
    internal abstract class BaseQueryRepository<TQueryModel> : IQueryRepository<TQueryModel>
        where TQueryModel : class, IQueryModel
    {
        protected readonly DbSet<TQueryModel> _dbSet;
        protected readonly IQueryable<TQueryModel> _dbSetWithInclude;

        public BaseQueryRepository(DbSet<TQueryModel> dbSet, IQueryable<TQueryModel> dbSetWithInclude)
        {
            _dbSet = dbSet;
            _dbSetWithInclude = dbSetWithInclude;
        }

        public async Task<TQueryModel?> GetByIdAsync(Guid id)
        {
            return await _dbSetWithInclude
                .Where(a => a.Id == id)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public Task<IQueryable<TQueryModel>> GetAllAsync(Expression<Func<TQueryModel, bool>>? filter = null)
        {
            var query = _dbSetWithInclude.AsNoTracking().AsQueryable();

            if (filter is not null)
                query = query.Where(filter);

            return Task.FromResult(query);
        }
    }
}
