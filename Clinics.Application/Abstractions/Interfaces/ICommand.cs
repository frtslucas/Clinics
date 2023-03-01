namespace Clinics.Application.Abstractions.Interfaces
{
    public interface ICommand
    { 
    }

    public interface ICommand<TResult> : ICommand
    {
    }
}
