using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Command.SetAgreedValue
{
    public record SetAgreedValueCommand : ICommand
    {
        public Guid PatientId { get; set; } = default!;
        public decimal AgreedValue { get; set; }
    }
}
