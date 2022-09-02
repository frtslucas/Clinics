using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.PatientAggregate;

namespace Clinics.Application.Query.Providers
{
    public interface IPatientQueryProvider : IQueryProvider<PatientQueryModel>
    {
    }
}
