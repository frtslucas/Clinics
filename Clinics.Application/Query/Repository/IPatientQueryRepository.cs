using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.PatientAggregate;

namespace Clinics.Application.Query.Repository
{
    public interface IPatientQueryRepository : IQueryRepository<PatientQueryModel>
    {
        Task<IQueryable<PatientQueryModel>> GetAllPatientsWithSessionsAndPaymentsFilteredByYearAndMonthAsync(int year, int month);
        Task<PatientQueryModel?> GetPatientByNameAsync(string name);
    }
}
