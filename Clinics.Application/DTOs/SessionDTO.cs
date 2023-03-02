using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.DTOs
{
    public class SessionDTO : BaseEntityDTO, IEntityDTO, IAggregateRootDTO
    {
        public Guid PatientId { get; set; }
        public string? PatientName { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public string? Observations { get; set; }
        public bool Done { get; set; }
        public bool Paid { get; set; }
        public decimal? TotalPaid { get; set; }
        public decimal? TotalPending { get; set; }

        public IList<SessionPaymentDTO>? Payments { get; set; }
    }
}
