using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Abstractions;

namespace Clinics.Application.DTOs
{
    public class PaymentDTO : BaseEntityDTO, IEntityDTO, IAggregateRootDTO
    {
        public Guid PatientId { get; set; }

        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}
