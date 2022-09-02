using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Application.Command.InactivatePatient
{
    internal sealed class InactivatePatientCommandHandler : ICommandHandler<InactivatePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public InactivatePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Result> HandleAsync(InactivatePatientCommand command)
        {
            var patientId = PatientId.FromGuid(command.PatientId);
            var patient = await _patientRepository.FindByIdAsync(patientId);

            if (patient is null)
                return Result.Fail(Error.NotFound);

            patient.Inactivate();

            await _patientRepository.UpdateAsync(patient);

            return Result.Success;
        }
    }
}
