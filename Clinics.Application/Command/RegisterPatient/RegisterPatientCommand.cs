using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;

namespace Clinics.Application.Command.RegisterPatient
{
    public record RegisterPatientCommand : ICommand<Patient>
    {
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; } = default!;
        public string Occupation { get; set; } = null!;
        public string PlaceOfBirth { get; set; } = null!;
        public string? StreetAddress { get; set; }
        public int? StreetNumber { get; set; }
        public string? ExtraLineAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? RG { get; set; }
        public string? CPF { get; set; }
        public decimal AgreedValue { get; set; }
        public byte EstimatedMonthSessions { get; set; }
    }
}
