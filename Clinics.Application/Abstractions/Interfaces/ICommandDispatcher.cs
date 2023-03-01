namespace Clinics.Application.Abstractions.Interfaces
{
    public interface ICommandDispatcher
    {
        Task<Result> DispatchAsync<TCommand>(TCommand command)
            where TCommand : ICommand;

        Task<Result<TResult>> DispatchAsync<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>;
    }
}
