using Clinics.Application.Abstractions.Interfaces;
using Clinics.Infrastructure.EntityFramework.Command;

namespace Clinics.Infrastructure
{
    internal sealed class UnityOfWork : IUnityOfWork
    {
        private readonly CommandDbContext _dbContext;

        public UnityOfWork(CommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
