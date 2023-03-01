using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PaymentAggregate;
using Clinics.Domain.Aggregates.SessionAggregate;
using Clinics.Domain.Aggregates.SessionAggregate.Entities;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;
using Clinics.Domain.Shared;

namespace Clinics.Application.Command.AddPaymentToSession
{
    internal sealed class AddPaymentToSessionCommandHandler : ICommandHandler<AddPaymentToSessionCommand, Payment>
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IPaymentRepository _paymentRepository;

        public AddPaymentToSessionCommandHandler(ISessionRepository sessionRepository, IPaymentRepository paymentRepository)
        {
            _sessionRepository = sessionRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<Result<Payment>> HandleAsync(AddPaymentToSessionCommand command)
        {
            var session = await _sessionRepository.FindByIdAsync(SessionId.FromGuid(command.SessionId));

            if (session is null)
                return Result<Payment>.Fail(Error.NotFound);

            var value = Value.FromDecimal(command.PaymentValue);

            var sessionPayment = new SessionPayment(value, command.PaymentDate);
            session.AddPayment(sessionPayment);

            await _sessionRepository.UpdateAsync(session);

            var payment = new Payment(session.PatientId, value, command.PaymentDate);

            await _paymentRepository.AddAsync(payment);

            return Result<Payment>.SuccessWithValue(payment);
        }
    }
}
