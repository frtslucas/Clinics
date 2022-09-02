using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Domain.Aggregates.PatientAggregate
{
    public interface IPatientRepository : IRepository<Patient, PatientId>
    {
    }
}
