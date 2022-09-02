namespace Clinics.Application.Abstractions.Interfaces
{
    internal interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task<Result> HandleAsync(TCommand command);
    }
}
