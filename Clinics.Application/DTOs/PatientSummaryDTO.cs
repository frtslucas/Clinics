using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.DTOs
{
    public class PatientSummaryDTO : ISummaryDTO
    {
        public Guid Id { get; set; }
        public string Initials { get; set; } = null!;
    }
}
