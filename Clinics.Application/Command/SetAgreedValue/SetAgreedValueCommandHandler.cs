using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Application.Command.SetAgreedValue
{
    internal sealed class SetAgreedValueCommandHandler : ICommandHandler<SetAgreedValueCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public SetAgreedValueCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Result> HandleAsync(SetAgreedValueCommand command)
        {
            var patientId = PatientId.FromGuid(command.PatientId);
            var patient = await _patientRepository.FindByIdAsync(patientId);

            if (patient is null)
                return Result.Fail(Error.NotFound);

            var agreedValue = MoneyValue.FromDecimal(command.AgreedValue);
            patient.SetAgreedValue(agreedValue);

            await _patientRepository.UpdateAsync(patient);

            return Result.Success;
        }
    }
}
