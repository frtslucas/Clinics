using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Shared;

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
            var patient = await _patientRepository.FindByIdAsync(PatientId.FromGuid(command.PatientId));

            if (patient is null)
                return Result.Fail(Error.NotFound);

            var agreedValue = Value.FromDecimal(command.AgreedValue);
            patient.SetAgreedValue(agreedValue);

            await _patientRepository.UpdateAsync(patient);

            return Result.Success;
        }
    }
}
