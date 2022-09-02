using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.PatientAggregate;
using Clinics.Application.Query.Providers;
using Microsoft.EntityFrameworkCore;

namespace Clinics.Infrastructure.EntityFramework.Query.QueryProviders
{
    internal sealed class PatientQueryProvider : BaseQueryProvider<PatientQueryModel>, IQueryProvider<PatientQueryModel>, IPatientQueryProvider
    {
        public PatientQueryProvider(QueryDbContext dbContext) : base(dbContext.Patients, dbContext.Patients.Include(p => p.Sessions).ThenInclude(s => s.Payments))
        {
        }
    }
}
