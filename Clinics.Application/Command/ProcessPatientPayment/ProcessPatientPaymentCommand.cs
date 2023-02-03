using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Command.ProcessPatientPayment
{
    public record ProcessPatientPaymentCommand : ICreateCommand
    {
        public Guid Id { get; set; } = default!;
        public Guid PatientId { get; set; } = default!;
        public decimal MoneyValue { get; set; }
        public DateTime Date { get; set; }
    }
}
