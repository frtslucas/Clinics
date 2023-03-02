using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Aggregates.PaymentAggregate;
using Clinics.Domain.Aggregates.SessionAggregate;
using Clinics.Domain.Services.PaymentProcessor;
using Clinics.Domain.Shared;

namespace Clinics.Application.Command.ProcessPatientPayment
{
    internal sealed class ProcessPatientPaymentCommandHandler : ICommandHandler<ProcessPatientPaymentCommand, Payment>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IPaymentProcessor _paymentProcessor;

        public ProcessPatientPaymentCommandHandler(
            IPatientRepository patientRepository,
            IPaymentRepository paymentRepository,
            ISessionRepository sessionRepository,
            IPaymentProcessor paymentProcessor)
        {
            _patientRepository = patientRepository;
            _paymentRepository = paymentRepository;
            _sessionRepository = sessionRepository;
            _paymentProcessor = paymentProcessor;
        }

        public async Task<Result<Payment>> HandleAsync(ProcessPatientPaymentCommand command)
        {
            var patientId = PatientId.FromGuid(command.PatientId);

            if (!await _patientRepository.ExistsByIdAsync(patientId))
                return Result<Payment>.Fail(Error.NotFound);

            var payment = new Payment(patientId, Value.FromDecimal(command.ValueAmount), command.Date);
            
            var result = await _paymentProcessor.AssignPaymentToSessionsAsync(payment);

            await _sessionRepository.UpdateManyAsync(result.SessionsUpdated);
            await _sessionRepository.AddManyAsync(result.NewSessions);

            await _paymentRepository.AddAsync(payment);
            
            return Result<Payment>.SuccessWithValue(payment);
        }
    }
}
