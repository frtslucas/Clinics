using System.Linq.Expressions;

namespace Clinics.Application.Abstractions.Interfaces
{
    public interface IQueryProvider<TQueryModel> : IQueryProvider<TQueryModel, Guid>
        where TQueryModel : class, IQueryModel
    {
    }

    public interface IQueryProvider<TQueryModel, TIdType>
        where TQueryModel : class, IQueryModel
    {
        Task<TQueryModel?> GetByIdAsync(TIdType id);
        Task<IQueryable<TQueryModel>> GetAllAsync(Expression<Func<TQueryModel, bool>>? filter = null);
    }
}
