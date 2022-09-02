using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Command.MarkSessionAsDone
{
    public record MarkSessionAsDoneCommand : ICommand
    {
        public Guid PatientId { get; set; } = default!;
        public Guid SessionId { get; set; } = default!;
        public decimal? PaymentValue { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
