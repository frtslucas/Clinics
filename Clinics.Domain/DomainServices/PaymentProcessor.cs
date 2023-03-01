using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PaymentAggregate;
using Clinics.Domain.Aggregates.SessionAggregate;
using Clinics.Domain.Shared;

namespace Clinics.Domain.DomainServices
{
    public interface IPaymentProcessor : IDomainService
    {
        Task<IReadOnlyList<Session>> AssignPaymentToSessionsAsync(Payment payment);
    }

    public sealed class PaymentProcessor : IPaymentProcessor, IDomainService
    {
        private readonly ISessionRepository _sessionRepository;

        public PaymentProcessor(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<IReadOnlyList<Session>> AssignPaymentToSessionsAsync(Payment payment)
        {
            var sessionToPay = await _sessionRepository.GetUnpaidSessionsFromPatientAsync(payment.PatientId);

            var remainingValue = payment.Value;

            foreach (var session in sessionToPay)
            {
                if (remainingValue == Value.Zero)
                    break;

                var paidValue = Value.Min(remainingValue, session.UnpaidValue);

                session.AddPayment(paidValue, payment.Date);

                remainingValue -= paidValue;
            }

            return sessionToPay;
        }
    }
}
