using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.PatientAggregate;
using Clinics.Application.Query.Providers;
using Microsoft.EntityFrameworkCore;

namespace Clinics.Infrastructure.EntityFramework.Query.QueryProviders
{
    internal sealed class PatientQueryProvider : BaseQueryProvider<PatientQueryModel>, IQueryProvider<PatientQueryModel>, IPatientQueryProvider
    {
        public PatientQueryProvider(QueryDbContext dbContext) : base(
            dbContext.Patients, 
            dbContext.Patients
                .Include(p => p.Sessions.OrderBy(s => s.Date)).ThenInclude(s => s.Payments)
                .Include(p => p.Payments.OrderBy(p => p.Date)))
        {
        }
    }
}
