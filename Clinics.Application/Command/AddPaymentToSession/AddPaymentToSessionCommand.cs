using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PaymentAggregate;

namespace Clinics.Application.Command.AddPaymentToSession
{
    public record AddPaymentToSessionCommand : ICommand<Payment>
    {
        public Guid SessionId { get; set; }
        public decimal PaymentValue { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
