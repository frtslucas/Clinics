using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.DTOs;

namespace Clinics.Application.Query.GetPatientByNameQuery
{
    public class GetPatientByNameQuery : IQuery<PatientDTO>
    {
        public string Name { get; set; } = null!;
    }
}
