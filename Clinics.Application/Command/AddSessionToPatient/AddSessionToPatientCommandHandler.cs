using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Application.Command.AddSessionToPatient
{
    internal sealed class AddSessionToPatientCommandHandler : ICommandHandler<AddSessionToPatientCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public AddSessionToPatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Result> HandleAsync(AddSessionToPatientCommand command)
        {
            var patientId = PatientId.FromGuid(command.PatientId);
            var patient = await _patientRepository.FindByIdAsync(patientId);

            if (patient is null)
                return Result.Fail(Error.NotFound);

            patient.AddSession(command.Date, command.Observations);

            await _patientRepository.UpdateAsync(patient);

            return Result.Success;
        }
    }
}
