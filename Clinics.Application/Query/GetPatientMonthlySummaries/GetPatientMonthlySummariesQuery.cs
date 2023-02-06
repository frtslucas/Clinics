using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.DTOs;

namespace Clinics.Application.Query.GetPatientMonthlySummaries
{
    public class GetPatientMonthlySummariesQuery : IQuery<IEnumerable<PatientMonthlySummaryDTO>>
    {
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
