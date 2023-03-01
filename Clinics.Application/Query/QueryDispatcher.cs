using Clinics.Application.Abstractions.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Clinics.Application.Query
{
    internal sealed class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult?> QueryAsync<TQuery, TResult>(TQuery query)
            where TQuery : class, IQuery<TResult>
        {
            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();

            return await handler.HandleAsync(query);
        }
    }
}
