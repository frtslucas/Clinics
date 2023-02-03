using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Command.AddSessionToPatient
{
    public record AddSessionToPatientCommand : ICreateCommand
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
        public string? Observations { get; set; }
        public bool Done { get; set; }
    }
}
