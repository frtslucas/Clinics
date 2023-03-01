namespace Clinics.Application.Abstractions.Interfaces
{
    internal interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task<Result> HandleAsync(TCommand command);
    }

    internal interface ICommandHandler<TCommand, TResult>
        where TCommand : ICommand
    {
        Task<Result<TResult>> HandleAsync(TCommand command);
    }
}
