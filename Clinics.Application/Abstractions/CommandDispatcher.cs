using Clinics.Application.Abstractions.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Clinics.Application.Abstractions
{
    internal sealed class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            var unityOfWork = scope.ServiceProvider.GetRequiredService<IUnityOfWork>();

            await handler.HandleAsync(command);
            await unityOfWork.SaveChangesAsync();
        }
    }
}
