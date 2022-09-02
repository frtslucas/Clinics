using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Aggregates.PatientAggregate;

namespace Clinics.Application.Command.ReactivatePatient
{
    internal sealed class ReactivatePatientCommandHandler : ICommandHandler<ReactivatePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public ReactivatePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Result> HandleAsync(ReactivatePatientCommand command)
        {
            var patientId = PatientId.FromGuid(command.PatientId);
            var patient = await _patientRepository.FindByIdAsync(patientId);

            if (patient is null)
                return Result.Fail(Error.NotFound);

            patient.Reactivate();

            await _patientRepository.UpdateAsync(patient);

            return Result.Success;
        }
    }
}
