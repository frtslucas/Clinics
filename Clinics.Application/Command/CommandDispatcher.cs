using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Clinics.Application.Command
{
    internal sealed class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<Result> DispatchAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
                var unityOfWork = scope.ServiceProvider.GetRequiredService<IUnityOfWork>();

                var result = await handler.HandleAsync(command);

                if (result.IsValid)
                    await unityOfWork.SaveChangesAsync();

                return result;
            }
            catch (DomainException exception)
            {
                return Result.Fail(Error.InvalidRequest, exception.Message);
            }
        }

        public async Task<Result<TResult>> DispatchAsync<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
                var unityOfWork = scope.ServiceProvider.GetRequiredService<IUnityOfWork>();

                var result = await handler.HandleAsync(command);

                if (result.IsValid)
                    await unityOfWork.SaveChangesAsync();

                return result;
            }
            catch (DomainException exception)
            {
                return Result<TResult>.Fail(Error.InvalidRequest, exception.Message);
            }
        }
    }
}
