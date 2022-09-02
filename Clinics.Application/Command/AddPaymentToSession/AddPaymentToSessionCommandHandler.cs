using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.Entities;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Application.Command.AddPaymentToSession
{
    internal sealed class AddPaymentToSessionCommandHandler : ICommandHandler<AddPaymentToSessionCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public AddPaymentToSessionCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Result> HandleAsync(AddPaymentToSessionCommand command)
        {
            var patientId = PatientId.FromGuid(command.PatientId);
            var patient = await _patientRepository.FindByIdAsync(patientId);

            if (patient is null)
                return Result.Fail(Error.NotFound);

            var sessionId = SessionId.FromGuid(command.SessionId);
            var payment = new Payment(MoneyValue.FromDecimal(command.PaymentValue), command.PaymentDate);

            patient.AddPaymentToSession(sessionId, payment);

            await _patientRepository.UpdateAsync(patient);

            return Result.Success;
        }
    }
}
