using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Clinics.Infrastructure.EntityFramework.Command.Repositories
{
    internal sealed class PatientRepository : BaseRepository<Patient, PatientId>, IRepository<Patient, PatientId>, IPatientRepository
    {
        public PatientRepository(CommandDbContext dbContext) : base(dbContext, dbContext.Patients.Include(p => p.Sessions).ThenInclude(s => s.Payments))
        {
        }
    }
}
