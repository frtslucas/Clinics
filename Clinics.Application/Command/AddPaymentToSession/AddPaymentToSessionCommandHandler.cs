using Clinics.Application.Abstractions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.SessionAggregate;
using Clinics.Domain.Aggregates.SessionAggregate.Entities;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;
using Clinics.Domain.Shared;

namespace Clinics.Application.Command.AddPaymentToSession
{
    internal sealed class AddPaymentToSessionCommandHandler : ICommandHandler<AddPaymentToSessionCommand>
    {
        private readonly ISessionRepository _sessionRepository;

        public AddPaymentToSessionCommandHandler(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<Result> HandleAsync(AddPaymentToSessionCommand command)
        {
            var session = await _sessionRepository.FindByIdAsync(SessionId.FromGuid(command.SessionId));

            if (session is null)
                return Result.Fail(Error.NotFound);

            var payment = new SessionPayment(MoneyValue.FromDecimal(command.PaymentValue), command.PaymentDate);

            session.AddPayment(payment);

            await _sessionRepository.UpdateAsync(session);

            return Result.Success;
        }
    }
}
