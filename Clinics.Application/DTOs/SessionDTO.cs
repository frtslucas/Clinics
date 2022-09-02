using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.DTOs
{
    public class SessionDTO : BaseEntityDTO, IEntityDTO
    {
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public string? Observations { get; set; }
        public bool Done { get; set; }
        public bool Paid { get; set; }

        public IList<PaymentDTO>? Payments { get; set; }
    }
}
