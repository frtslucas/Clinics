using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.DTOs
{
    public class SessionSummaryDTO : ISummaryDTO
    {
        public Guid Id { get; set; }
        public string PatientInitials { get; set; } = null!;
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public string? Observations { get; set; }
        public bool Done { get; set; }
        public bool Paid { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalPending { get; set; }
    }
}
