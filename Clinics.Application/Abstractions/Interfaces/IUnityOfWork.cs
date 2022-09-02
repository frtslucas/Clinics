namespace Clinics.Application.Abstractions.Interfaces
{
    public interface IUnityOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
