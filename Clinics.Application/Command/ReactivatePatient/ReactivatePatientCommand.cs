using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Command.ReactivatePatient
{
    public record ReactivatePatientCommand : ICommand
    {
        public Guid PatientId { get; set; } = default!;
    }
}
