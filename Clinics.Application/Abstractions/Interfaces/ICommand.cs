namespace Clinics.Application.Abstractions.Interfaces
{
    public interface ICreateCommand : ICreateCommand<Guid>
    {
    }

    public interface ICreateCommand<TIdType> : ICommand
    {
        TIdType Id { get; set; }
    }

    public interface ICommand
    {
    }
}
