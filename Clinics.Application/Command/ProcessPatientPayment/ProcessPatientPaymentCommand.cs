using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PaymentAggregate;

namespace Clinics.Application.Command.ProcessPatientPayment
{
    public record ProcessPatientPaymentCommand : ICommand<Payment>
    {
        public Guid PatientId { get; set; } = default!;
        public decimal MoneyValue { get; set; }
        public DateTime Date { get; set; }
    }
}
