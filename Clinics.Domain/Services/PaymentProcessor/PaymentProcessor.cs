using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PaymentAggregate;
using Clinics.Domain.Aggregates.SessionAggregate;
using Clinics.Domain.Shared;

namespace Clinics.Domain.Services.PaymentProcessor
{

    public sealed class PaymentProcessor : IPaymentProcessor, IDomainService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IPatientRepository _patientRepository;

        public PaymentProcessor(ISessionRepository sessionRepository, IPatientRepository patientRepository)
        {
            _sessionRepository = sessionRepository;
            _patientRepository = patientRepository;
        }

        public async Task<AssignPaymentToSessionsResult> AssignPaymentToSessionsAsync(Payment payment)
        {
            var sessionUpdated = await _sessionRepository.GetUnpaidSessionsFromPatientAsync(payment.PatientId);

            var remainingValue = payment.Value;

            foreach (var session in sessionUpdated)
            {
                if (remainingValue == Value.Zero)
                    break;

                var paidValue = Value.Min(remainingValue, session.UnpaidValue);

                session.AddPayment(paidValue, payment.Date);

                remainingValue -= paidValue;
            }

            var newSessions = new List<Session>();

            if (remainingValue != Value.Zero)
            {
                var patient = await _patientRepository.FindByIdAsync(payment.PatientId);

                if (patient is null)
                    throw new DomainException("Patient not found.");

                var lastPatientSession = sessionUpdated.LastOrDefault();

                lastPatientSession ??= await _sessionRepository.GetLastPatientSessionAsync(payment.PatientId);

                var lastSessionDate = lastPatientSession?.Date ?? DateTime.Now;

                var numberOfNewSessions = Math.Ceiling(remainingValue.Amount / patient.AgreedValue.Amount);

                for (int i = 1; i <= numberOfNewSessions; i++)
                {
                    lastSessionDate = lastSessionDate.AddDays(7);

                    var session = new Session(patient, lastSessionDate);

                    var paidValue = Value.Min(remainingValue, session.UnpaidValue);

                    session.AddPayment(paidValue, payment.Date);

                    remainingValue -= paidValue;

                    newSessions.Add(session);
                }
            }

            return new(sessionUpdated, newSessions);
        }
    }
}
