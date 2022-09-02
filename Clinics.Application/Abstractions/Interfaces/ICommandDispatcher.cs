namespace Clinics.Application.Abstractions.Interfaces
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
