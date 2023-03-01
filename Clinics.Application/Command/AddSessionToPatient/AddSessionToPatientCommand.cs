using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.SessionAggregate;

namespace Clinics.Application.Command.AddSessionToPatient
{
    public record AddSessionToPatientCommand : ICommand<Session>
    {
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
        public string? Observations { get; set; }
        public bool Done { get; set; }
    }
}
