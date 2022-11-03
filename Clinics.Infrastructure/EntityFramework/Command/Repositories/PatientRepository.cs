using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Infrastructure.EntityFramework.Command.Repositories
{
    internal sealed class PatientRepository : BaseRepository<Patient, PatientId>, IRepository<Patient, PatientId>, IPatientRepository
    {
        public PatientRepository(CommandDbContext dbContext) : base(dbContext.Patients, dbContext.Patients)
        {
        }
    }
}
