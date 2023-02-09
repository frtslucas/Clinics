using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.PatientAggregate;
using Clinics.Application.Query.Repository;
using Microsoft.EntityFrameworkCore;

namespace Clinics.Infrastructure.EntityFramework.Query.QueryRepository
{
    internal sealed class PatientQueryRepository : BaseQueryRepository<PatientQueryModel>, IQueryRepository<PatientQueryModel>, IPatientQueryRepository
    {
        public PatientQueryRepository(QueryDbContext dbContext) : base(
            dbContext.Patients,
            dbContext.Patients
                .Include(p => p.Sessions.OrderBy(s => s.Date)).ThenInclude(s => s.Payments)
                .Include(p => p.Payments.OrderBy(p => p.Date)))
        {
        }

        public Task<IQueryable<PatientQueryModel>> GetAllPatientsWithSessionsAndPaymentsFilteredByYearAndMonthAsync(int year, int month)
        {
            var query = _dbSet
                .Include(p => p.Sessions.Where(s => s.Date.Year == year && s.Date.Month == month).OrderBy(s => s.Date)).ThenInclude(s => s.Payments)
                .Include(p => p.Payments.Where(p => p.Date.Year == year && p.Date.Month == month).OrderBy(p => p.Date))
                .AsQueryable();

            return Task.FromResult(query);
        }
    }
}
