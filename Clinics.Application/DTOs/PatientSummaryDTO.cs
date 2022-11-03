using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.DTOs
{
    public class PatientSummaryDTO : ISummaryDTO
    {
        public Guid Id { get; set; }
        public string Initials { get; set; } = null!;
        public decimal? AgreedValue { get; set; }
        public byte EstimatedMonthSessions { get; set; }
        public decimal? EstimatedMonthTotal { get => AgreedValue.HasValue ? AgreedValue * EstimatedMonthSessions : null; }
        public byte ActualMonthSessions { get; set; }
        public decimal? ActualMonthTotal { get => AgreedValue.HasValue ? AgreedValue * ActualMonthSessions : null; }
        public decimal ToPay { get; set; }
    }
}
