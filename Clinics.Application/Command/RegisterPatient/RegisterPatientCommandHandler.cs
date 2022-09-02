using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Abstractions.ValueObjects;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Application.Command.RegisterPatient
{
    internal sealed class RegisterPatientCommandHandler : ICommandHandler<RegisterPatientCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public RegisterPatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Result> HandleAsync(RegisterPatientCommand command)
        {
            var id = PatientId.FromGuid(command.Id);
            var name = Name.FromString(command.Name);
            var occupation = Occupation.FromString(command.Occupation);
            var age = Age.FromDateTime(command.BrithDate);
            var placeOfBirth = PlaceOfBirth.FromString(command.PlaceOfBrith);
            var address = new Address(command.StreetAddress, command.StreetNumber, command.ExtraLineAddress, command.City, command.State);
            var agreedValue = MoneyValue.FromDecimal(command.AgreedValue);
            var rg = RG.FromString(command.RG);
            var cpf = CPF.FromString(command.CPF);

            var patient = new Patient(id, name, age, occupation, placeOfBirth, address, agreedValue, rg, cpf);

            await _patientRepository.AddAsync(patient);

            return Result.Success;
        }
    }
}
