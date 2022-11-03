using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Command.AddPaymentToSession
{
    public record AddPaymentToSessionCommand : ICommand
    {
        public Guid SessionId { get; set; }
        public decimal PaymentValue { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
