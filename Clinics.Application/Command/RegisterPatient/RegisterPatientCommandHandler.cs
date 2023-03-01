using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Shared;

namespace Clinics.Application.Command.RegisterPatient
{
    internal sealed class RegisterPatientCommandHandler : ICommandHandler<RegisterPatientCommand, Patient>
    {
        private readonly IPatientRepository _patientRepository;

        public RegisterPatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Result<Patient>> HandleAsync(RegisterPatientCommand command)
        {
            var name = Name.FromString(command.Name);
            var occupation = Occupation.FromString(command.Occupation);
            var age = Age.FromDateTime(command.BirthDate);
            var placeOfBirth = PlaceOfBirth.FromString(command.PlaceOfBirth);
            var address = !string.IsNullOrWhiteSpace(command.City) ? new Address(command.StreetAddress, command.StreetNumber, command.ExtraLineAddress, command.City, command.State) : null;
            var rg = !string.IsNullOrWhiteSpace(command.RG) ? RG.FromString(command.RG) : null;
            var cpf = !string.IsNullOrWhiteSpace(command.CPF) ? CPF.FromString(command.CPF) : null;
            var agreedValue = Value.FromDecimal(command.AgreedValue);

            var patient = new Patient(name, age, occupation, placeOfBirth, address, rg, cpf, agreedValue, command.EstimatedMonthSessions);

            await _patientRepository.AddAsync(patient);

            return Result<Patient>.SuccessWithValue(patient);
        }
    }
}
