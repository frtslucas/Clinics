using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Command.InactivatePatient
{
    public record InactivatePatientCommand : ICommand 
    {
        public Guid PatientId { get; set; } = default!;
    }
}
