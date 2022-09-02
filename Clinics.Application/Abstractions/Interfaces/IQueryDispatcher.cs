namespace Clinics.Application.Abstractions.Interfaces
{
    public interface IQueryDispatcher
    {
        Task<TResult?> QueryAsync<TQuery, TResult>(TQuery query)
            where TQuery : class, IQuery<TResult>;
    }
}
