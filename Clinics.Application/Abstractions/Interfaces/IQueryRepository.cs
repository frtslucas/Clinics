using System.Linq.Expressions;

namespace Clinics.Application.Abstractions.Interfaces
{
    public interface IQueryRepository<TQueryModel> : IQueryRepository<TQueryModel, Guid>
        where TQueryModel : class, IQueryModel
    {
    }

    public interface IQueryRepository<TQueryModel, TIdType>
        where TQueryModel : class, IQueryModel
    {
        Task<TQueryModel?> GetByIdAsync(TIdType id);
        Task<IQueryable<TQueryModel>> GetAllAsync(Expression<Func<TQueryModel, bool>>? filter = null);
    }
}
