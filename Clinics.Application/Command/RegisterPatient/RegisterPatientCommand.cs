using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Command.RegisterPatient
{
    public record RegisterPatientCommand : ICreateCommand
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = null!;
        public DateTime BrithDate { get; set; } = default!;
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
