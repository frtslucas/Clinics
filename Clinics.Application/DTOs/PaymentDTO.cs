using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.DTOs
{
    public class PaymentDTO : BaseEntityDTO, IEntityDTO
    {
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}
