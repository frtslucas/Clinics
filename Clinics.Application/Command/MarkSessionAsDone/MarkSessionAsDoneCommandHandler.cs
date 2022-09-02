using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.Entities;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Application.Command.MarkSessionAsDone
{
    internal sealed class MarkSessionAsDoneCommandHandler : ICommandHandler<MarkSessionAsDoneCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public MarkSessionAsDoneCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Result> HandleAsync(MarkSessionAsDoneCommand command)
        {
            var patientId = PatientId.FromGuid(command.PatientId);
            var patient = await _patientRepository.FindByIdAsync(patientId);

            if (patient is null)
                return Result.Fail(Error.NotFound);

            var sessionId = SessionId.FromGuid(command.SessionId);
            var payment = command.PaymentValue.HasValue && command.PaymentDate.HasValue ? 
                new Payment(MoneyValue.FromDecimal(command.PaymentValue.Value), command.PaymentDate.Value) : 
                null;

            patient.MarkSessionAsDone(sessionId, payment);

            await _patientRepository.UpdateAsync(patient);

            return Result.Success;
        }
    }
}
