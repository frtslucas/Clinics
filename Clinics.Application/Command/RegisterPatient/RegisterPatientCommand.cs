using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Command.RegisterPatient
{
    public record RegisterPatientCommand : ICreateCommand
    {
        public Guid Id { get; set; } = default!;
        public string Name { get; set; } = null!;
        public DateTime BrithDate { get; set; } = default!;
        public string Occupation { get; set; } = null!;
        public string PlaceOfBrith { get; set; } = null!;
        public decimal AgreedValue { get; set; }
        public string? StreetAddress { get; set; }
        public int? StreetNumber { get; set; }
        public string? ExtraLineAddress { get; set; }
        public string City { get; set; } = null!;
        public string? State { get; set; }
        public string RG { get; set; } = null!;
        public string CPF { get; set; } = null!;
    }
}
